/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET通用权限管理平台
 * 前后端分离架构，开箱即用，紧随前沿技术。<br/><a href='https://gitee.com/Run2948/Admin.NET/'>https://gitee.com/Run2948/Admin.NET</a>
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
/**
 * 文件信息表
 * @export
 * @interface SysFile
 */
export interface SysFile {
    /**
     * 主键Id
     * @type {number}
     * @memberof SysFile
     */
    id?: any;
    /**
     * 创建时间
     * @type {Date}
     * @memberof SysFile
     */
    createdTime?: any | null;
    /**
     * 更新时间
     * @type {Date}
     * @memberof SysFile
     */
    updatedTime?: any | null;
    /**
     * 创建者Id
     * @type {number}
     * @memberof SysFile
     */
    createdUserId?: any | null;
    /**
     * 创建者名称
     * @type {string}
     * @memberof SysFile
     */
    createdUserName?: any | null;
    /**
     * 修改者Id
     * @type {number}
     * @memberof SysFile
     */
    updatedUserId?: any | null;
    /**
     * 修改者名称
     * @type {string}
     * @memberof SysFile
     */
    updatedUserName?: any | null;
    /**
     * 文件存储位置（1:阿里云，2:腾讯云，3:minio，4:本地）
     * @type {number}
     * @memberof SysFile
     */
    fileLocation?: any;
    /**
     * 文件仓库
     * @type {string}
     * @memberof SysFile
     */
    fileBucket?: any | null;
    /**
     * 文件名称（上传时候的文件名）
     * @type {string}
     * @memberof SysFile
     */
    fileOriginName?: any | null;
    /**
     * 文件后缀
     * @type {string}
     * @memberof SysFile
     */
    fileSuffix?: any | null;
    /**
     * 文件大小kb
     * @type {string}
     * @memberof SysFile
     */
    fileSizeKb?: any | null;
    /**
     * 文件大小信息，计算后的
     * @type {string}
     * @memberof SysFile
     */
    fileSizeInfo?: any | null;
    /**
     * 存储到bucket的名称（文件唯一标识id）
     * @type {string}
     * @memberof SysFile
     */
    fileObjectName?: any | null;
    /**
     * 存储路径
     * @type {string}
     * @memberof SysFile
     */
    filePath?: any | null;
}
