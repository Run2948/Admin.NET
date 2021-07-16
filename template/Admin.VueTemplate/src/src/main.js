// with polyfills
import 'core-js/stable'
import 'regenerator-runtime/runtime'
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store/'
import { VueAxios } from './utils/request'
// WARNING: `mockjs` NOT SUPPORT `IE` PLEASE DO NOT USE IN `production` ENV.
import './mock'

import bootstrap from './core/bootstrap'
import './core/lazy_use'
import './permission'
import './utils/filter'
import './components/global.less'
//#if (EnableTenant)
import socket from './utils/socket'
//#endif
import { Dialog } from '@/components'
import { hasBtnPermission } from './utils/permissions'
import { sysApplication } from './utils/applocation'

import KFormDesign from 'k-form-design'
// import KFormDesign from 'k-form-design/lib/k-form-design-mini.umd.min'
import 'k-form-design/lib/k-form-design.css'
import 'ant-design-vue/dist/antd.less'
//#if (EnableTenant)
import dataV from '@jiaminghi/data-view'
//#endif

Vue.use(KFormDesign)
//#if (EnableTenant)
Vue.use(dataV)
Vue.use(socket, '/hubs/chatHub')
//#endif
Vue.use(VueAxios)
Vue.use(Dialog)
Vue.prototype.hasPerm = hasBtnPermission
Vue.prototype.applocation = sysApplication
Vue.config.productionTip = false

new Vue({
  router,
  store,
  created: bootstrap,
  render: h => h(App)
}).$mount('#app')
