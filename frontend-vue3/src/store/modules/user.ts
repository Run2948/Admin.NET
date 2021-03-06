import type { UserInfo } from '/#/store';
import type { ErrorMessageMode } from '/@/utils/http/axios/types';

import { defineStore } from 'pinia';
import { store } from '/@/store';

import { RoleEnum } from '/@/enums/roleEnum';
import { PageEnum } from '/@/enums/pageEnum';
import { ROLES_KEY, TOKEN_KEY, USER_INFO_KEY } from '/@/enums/cacheEnum';

import { getAuthCache, setAuthCache } from '/@/utils/auth';
import {
  GetUserInfoByUserIdModel,
  GetUserInfoByUserIdParams,
  LoginParams,
} from '/@/api/sys/model/userModel';

import { getUserInfoById, loginApi } from '/@/api/sys/user';

import { t, useI18n } from '/@/hooks/web/useI18n';
import { useMessage } from '/@/hooks/web/useMessage';
import router from '/@/router';
import { AuthApi } from '/@/api_base/apis/auth-api';
import { defHttp } from '/@/utils/http/axios';
import { LoginOutput, XnRestfulResultOfLoginOutput } from '/@/api_base/models';

const { createMessage, createErrorModal } = useMessage();

interface UserState {
  userInfo: Nullable<LoginOutput>;
  token?: string;
  roleList: RoleEnum[];
}

export const useUserStore = defineStore({
  id: 'app-user',
  state: (): UserState => ({
    // user info
    userInfo: null,
    // token
    token: undefined,
    // roleList
    roleList: [],
  }),
  getters: {
    getUserInfo(): LoginOutput {
      return this.userInfo || getAuthCache<LoginOutput>(USER_INFO_KEY) || {};
    },
    getToken(): string {
      return this.token || getAuthCache<string>(TOKEN_KEY);
    },
    getRoleList(): RoleEnum[] {
      return this.roleList.length > 0 ? this.roleList : getAuthCache<RoleEnum[]>(ROLES_KEY);
    },
  },
  actions: {
    setToken(info: string) {
      this.token = info;
      setAuthCache(TOKEN_KEY, info);
    },
    setRoleList(roleList: RoleEnum[]) {
      this.roleList = roleList;
      setAuthCache(ROLES_KEY, roleList);
    },
    setUserInfo(info: LoginOutput) {
      this.userInfo = info;
      setAuthCache(USER_INFO_KEY, info);
    },
    resetState() {
      this.userInfo = null;
      this.token = '';
      this.roleList = [];
    },
    /**
     * @description: login
     */
    async login(
      params: LoginParams & {
        goHome?: boolean;
        mode?: ErrorMessageMode;
      }
    ): Promise<LoginOutput | null> {
      try {
        const { goHome = true, mode, ...loginParams } = params;
        // const data = await loginApi(loginParams, mode);
        // const { token, userId } = data;

        var authApi = new AuthApi(undefined, undefined, defHttp.getAxios());
        var user = await authApi.loginPost(loginParams);
        if(user.data.code !== 200) {
          createMessage.error(user.data.message);
          return null;
        }

        // save token
        this.setToken("Bearer " + user.data.data);

        // get user info
        // const userInfo = await this.getUserInfoAction({ userId });
        const userInfo =  await authApi.getLoginUserGet();
        //const { roles } = userInfo.data;
        //const roleList = roles.map((item) => item.value) as RoleEnum[];
        this.setUserInfo(userInfo.data.data);
        //this.setRoleList(roleList);

        goHome && (await router.replace(PageEnum.BASE_HOME));
        return userInfo.data.data;
      } catch (error) {
        return null;
      }
    },
    // async getUserInfoAction({ userId }: GetUserInfoByUserIdParams) {
    //   const userInfo =  await getUserInfoById({ userId });
    //   const { roles } = userInfo;
    //   const roleList = roles.map((item) => item.value) as RoleEnum[];
    //   this.setUserInfo(userInfo);
    //   this.setRoleList(roleList);
    //   return userInfo;
    // },
    /**
     * @description: logout
     */
    logout(goLogin = false) {
      goLogin && router.push(PageEnum.BASE_LOGIN);
    },

    /**
     * @description: Confirm before logging out
     */
    confirmLoginOut() {
      const { createConfirm } = useMessage();
      const { t } = useI18n();
      createConfirm({
        iconType: 'warning',
        title: t('sys.app.logoutTip'),
        content: t('sys.app.logoutMessage'),
        onOk: async () => {
          await this.logout(true);
        },
      });
    },
  },
});

// Need to be used outside the setup
export function useUserStoreWidthOut() {
  return useUserStore(store);
}
