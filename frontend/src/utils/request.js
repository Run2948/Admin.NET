import Vue from 'vue'
import axios from 'axios'
import store from '@/store'
// import router from './router'
import { message, Modal, notification } from 'ant-design-vue' /// es/notification
import { VueAxios } from './axios'
import { ACCESS_TOKEN } from '@/store/mutation-types'

// 创建 axios 实例
const service = axios.create({
  baseURL: '/api', // api base_url
  timeout: 6000 // 请求超时时间
})

const err = error => {
  if (error.response) {
    const data = error.response.data
    const token = Vue.ls.get(ACCESS_TOKEN)

    if (error.response.status === 403) {
      console.log('服务器403啦，要重新登录！')
      notification.error({
        message: 'Forbidden',
        description: data.message
      })
    }
    if (error.response.status === 500) {
      if (data.message.length > 0) {
        message.error(data.message)
      }
    }
    if (error.response.status === 401 && !(data.result && data.result.isLogin)) {
      notification.error({
        message: 'Unauthorized',
        description: 'Authorization verification failed'
      })
      if (token) {
        store.dispatch('Logout').then(() => {
          setTimeout(() => {
            window.location.reload()
          }, 1500)
        })
      }
    }
  }
  return Promise.reject(error)
}

// request interceptor
service.interceptors.request.use(config => {
  const token = Vue.ls.get(ACCESS_TOKEN)
  const refreshToken = Vue.ls.get('X-Access-Token')
  if (token) {
    config.headers['Authorization'] = 'Bearer ' + token
  }
  if (refreshToken) {
    config.headers['X-Authorization'] = 'Bearer ' + refreshToken
  }
  return config
}, err)

/**
 * response interceptor
 * 所有请求统一返回
 */
service.interceptors.response.use(response => {
  // LocalStorage 存储的 token 和 refreshToken，不设定过期时间，由服务端统一处理
  if (response.headers['access-token']) {
    Vue.ls.set(ACCESS_TOKEN, response.headers['access-token'] /*, 7 * 24 * 60 * 60 * 1000 */)
    store.commit('SET_TOKEN', response.headers['access-token'])
  }
  if (response.headers['x-access-token']) {
    Vue.ls.set('X-Access-Token', response.headers['x-access-token'] /*, 7 * 24 * 60 * 60 * 1000 */)
  }
  if (response.request.responseType === 'blob') {
    return response
  }
  const resData = response.data
  const code = response.data.code
  if (!store.state.app.hasError) {
    if (code === 401 /* || code === 1011006 || code === 1011007 || code === 1011008 || code === 1011009 */) {
      Modal.error({
        title: '提示：',
        content: resData.message,
        okText: '重新登录',
        onOk: () => {
          Vue.ls.remove(ACCESS_TOKEN)
          Vue.ls.remove('X-Access-Token')
          store.dispatch('SetHasError', false)
          window.location.reload()
        }
      })
      store.dispatch('SetHasError', true)
    }
    // if (code === 1013002 || code === 1016002 || code === 1015002) {
    //   message.error(response.data.message)
    //   return response.data
    // }
  }
  return resData
}, err)

const installer = {
  vm: {},
  install(Vue) {
    Vue.use(VueAxios, service)
  }
}

export { installer as VueAxios, service as axios }
