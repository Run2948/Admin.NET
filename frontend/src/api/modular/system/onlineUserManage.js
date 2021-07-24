import {
  axios
} from '@/utils/request'

/**
 * 分页在线用户列表
 *
 * @author 写意
 * @date 2021/7/21 23:34
 */
export function sysOnlineUserPage(parameter) {
  return axios({
    url: '/sysOnlineUser/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 在线用户列表
 *
 * @author yubaoshan
 * @date 2020/6/8 11:11
 */
export function sysOnlineUserList(parameter) {
  return axios({
    url: '/sysOnlineUser/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 强制下线
 *
 * @author yubaoshan
 * @date 2020/6/8 11:11
 */
export function sysOnlineUserForceExist(parameter) {
  return axios({
    url: '/sysOnlineUser/forceExist',
    method: 'post',
    data: parameter
  })
}
