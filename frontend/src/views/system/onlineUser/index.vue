<template>
  <div>
    <x-card v-if="hasPerm('sysOnlineUser:page')">
      <div slot="content" class="table-page-search-wrapper">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="搜索">
                <a-input v-model="queryParam.searchValue" allow-clear placeholder="请输入账号或姓名" />
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
              <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </x-card>
    <a-card :bordered="false">
      <!-- <a-table size="middle" :columns="columns" :dataSource="loadData" :pagination="false" :loading="loading">
           <span slot="lastLoginAddress" slot-scope="text">
             <ellipsis :length="20" tooltip>{{ text }}</ellipsis>
           </span>
           <span slot="lastLoginBrowser" slot-scope="text">
             <ellipsis :length="20" tooltip>{{ text }}</ellipsis>
           </span>
           <span slot="action" slot-scope="text, record">
             <a-popconfirm
               v-if="hasPerm('sysOnlineUser:forceExist')"
               placement="topRight"
               title="是否强制下线该用户？"
               @confirm="() => forceExist(record)">
               <a>强制下线</a>
             </a-popconfirm>
           </span>
         </a-table> -->
      <s-table
        ref="table"
        :columns="columns"
        :data="loadData"
        :alert="true"
        :rowKey="record => record.id"
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      >
        <span slot="lastLoginAddress" slot-scope="text">
          <ellipsis :length="20" tooltip>{{ text }}</ellipsis>
        </span>
        <span slot="lastLoginBrowser" slot-scope="text">
          <ellipsis :length="20" tooltip>{{ text }}</ellipsis>
        </span>
        <span slot="action" slot-scope="text, record">
          <a-popconfirm
            v-if="hasPerm('sysOnlineUser:forceExist')"
            placement="topRight"
            title="是否强制下线该用户？"
            @confirm="() => forceExist(record)"
          >
            <a>强制下线</a>
          </a-popconfirm>
        </span>
      </s-table>
    </a-card>
  </div>
</template>
<script>
import store from '@/store'
import { STable, Ellipsis, XCard } from '@/components'
import { sysOnlineUserForceExist, sysOnlineUserPage } from '@/api/modular/system/onlineUserManage'
export default {
  components: {
    XCard,
    STable,
    Ellipsis
  },
  data() {
    return {
      // 查询参数
      queryParam: {},
      // 表头
      columns: [
        // {
        //   title: '用户Id',
        //   dataIndex: 'userId'
        // },
        {
          title: '账号',
          dataIndex: 'account'
        },
        {
          title: '姓名',
          dataIndex: 'name'
        },
        {
          title: '登录IP',
          dataIndex: 'lastLoginIp'
        },
        {
          title: '登录时间',
          dataIndex: 'lastTime'
        },
        {
          title: '浏览器',
          dataIndex: 'lastLoginBrowser',
          scopedSlots: {
            customRender: 'lastLoginBrowser'
          }
        },
        {
          title: '操作系统',
          dataIndex: 'lastLoginOs'
        }
      ],
      // loading: true,
      loadData: parameter => {
        return sysOnlineUserPage(Object.assign(parameter, this.queryParam)).then(res => {
          return res.data
        })
      },
      selectedRowKeys: [],
      selectedRows: []
    }
  },
  // 进页面加载
  created() {
    // 如果是超级管理员
    // eslint-disable-next-line eqeqeq
    if (store.getters.admintype == '1') {
      this.columns.push({
        title: '租户',
        dataIndex: 'tenantName'
      })
    }

    if (this.hasPerm('sysOnlineUser:forceExist')) {
      this.columns.push({
        title: '操作',
        width: '150px',
        dataIndex: 'action',
        scopedSlots: {
          customRender: 'action'
        }
      })
    }
  },
  mounted() {
    const that = this
    setTimeout(() => {
      that.$refs.table.refresh(true)
    }, 1000)
  },
  methods: {
    forceExist(record) {
      const that = this
      sysOnlineUserForceExist(record)
        .then(res => {
          if (res.success) {
            this.$message.success('强制下线成功')
            if (this.$store.getters.userInfo.id !== record.userId) {
              // 重新加载表格
              setTimeout(() => {
                that.$refs.table.refresh(false)
              }, 1000)
            }
          } else {
            this.$message.error('强制下线失败：' + res.message)
          }
        })
        .catch(err => {
          this.$message.error('强制下线错误：' + err.message)
        })
    },
    onSelectChange(selectedRowKeys, selectedRows) {
      this.selectedRowKeys = selectedRowKeys
      this.selectedRows = selectedRows
    }
  }
}
</script>
<style lang="less">
.table-operator {
  margin-bottom: 18px;
}

button {
  margin-right: 8px;
}
</style>
