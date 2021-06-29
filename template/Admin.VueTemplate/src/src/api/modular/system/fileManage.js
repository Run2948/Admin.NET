import { axios } from '@/utils/request'

/**
 * 分页查询文件信息表
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoPage (parameter) {
  return axios({
    url: '/sysFileInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 获取全部文件信息表
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoList (parameter) {
  return axios({
    url: '/sysFileInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 上传文件
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoUpload (parameter) {
  return axios({
    url: '/sysFileInfo/upload',
    method: 'post',
    data: parameter
  })
}

/**
 * 上传文件后公开路径
 *
 * @author zhujinrun
 * @date 2021/6/27 00:20
 */
export function sysFileInfoUploadPublic (parameter) {
  return axios({
    url: '/sysFileInfo/uploadPublic',
    method: 'post',
    data: parameter
  })
}

/**
 * 上传头像
 *
 * @author zuohuaijun
 * @date 2021/4/23 00:20
 */
export function sysFileInfoUploadAvatar (parameter) {
  return axios({
    url: '/sysFileInfo/uploadAvatar',
    method: 'post',
    data: parameter
  })
}

/**
 * 下载文件
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoDownload (parameter) {
  return axios({
    url: '/sysFileInfo/download',
    method: 'get',
    params: parameter,
    responseType: 'blob'
  })
}

/**
 * 查看图片
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoPreview (parameter) {
  return axios({
    url: '/sysFileInfo/preview',
    method: 'get',
    params: parameter,
    responseType: 'arraybuffer'
  })
}

/**
 * 公开文件
 *
 * @author zhujinrun
 * @date 2021/6/27 00:20
 */
export function sysFileInfoPublic (parameter) {
  return axios({
    url: '/sysFileInfo/public',
    method: 'get',
    params: parameter
  })
}

/**
 * 查看详情文件信息表
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoDetail (parameter) {
  return axios({
    url: '/sysFileInfo/detail',
    method: 'get',
    params: parameter
  })
}

/**
 * 删除文件信息表
 *
 * @author yubaoshan
 * @date 2020/6/30 00:20
 */
export function sysFileInfoDelete (parameter) {
  return axios({
    url: '/sysFileInfo/delete',
    method: 'post',
    data: parameter
  })
}
