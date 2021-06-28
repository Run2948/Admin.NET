/*
 * @Author: your name
 * @Date: 2021-04-17 17:45:37
 * @LastEditTime: 2021-04-17 18:03:59
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \frontend\src\api\modular\system\logManage.js
 */
import { axios } from '@/utils/request'

/**
 * 查询访问日志
 *
 * @author yubaoshan
 * @date 2020/5/19 11:57
 */
export function sysVisLogPage (parameter) {
  return axios({
    url: '/sysVisLog/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 查询操作日志
 *
 * @author yubaoshan
 * @date 2020/5/19 11:57
 */
export function sysOpLogPage (parameter) {
  return axios({
    url: '/sysOpLog/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 查询异常日志
 *
 * @author yubaoshan
 * @date 2020/5/19 11:57
 */
export function sysExLogPage (parameter) {
  return axios({
    url: '/sysExLog/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 清空访问日志
 *
 * @author yubaoshan
 * @date 2020/6/23 23:09
 */
export function sysVisLogDelete (parameter) {
  return axios({
    url: '/sysVisLog/delete',
    method: 'post',
    data: parameter
  })
}

/**
 * 清空登录日志
 *
 * @author yubaoshan
 * @date 2020/6/23 23:09
 */
export function sysOpLogDelete (parameter) {
  return axios({
    url: '/sysOpLog/delete',
    method: 'post',
    data: parameter
  })
}

/**
 * 清空异常日志
 *
 * @author yubaoshan
 * @date 2020/6/23 23:09
 */
export function sysExLogDelete (parameter) {
  return axios({
    url: '/sysExLog/delete',
    method: 'post',
    data: parameter
  })
}
