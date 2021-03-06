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
import globalAxios, { AxiosPromise, AxiosInstance } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
import { AddNoticeInput } from '../models';
import { ChangeStatusNoticeInput } from '../models';
import { DeleteNoticeInput } from '../models';
import { UpdateNoticeInput } from '../models';
import { XnRestfulResultOfNoticeDetailOutput } from '../models';
import { XnRestfulResultOfObject } from '../models';
/**
 * NoticeApi - axios parameter creator
 * @export
 */
export const NoticeApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 增加通知公告
         * @param {AddNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeAddPost: async (body?: AddNoticeInput, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/add`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            localVarHeaderParameter['Content-Type'] = 'application/xml';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 修改通知公告状态
         * @param {ChangeStatusNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeChangeStatusPost: async (body?: ChangeStatusNoticeInput, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/changeStatus`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            localVarHeaderParameter['Content-Type'] = 'application/xml';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 删除通知公告
         * @param {DeleteNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeDeletePost: async (body?: DeleteNoticeInput, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/delete`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            localVarHeaderParameter['Content-Type'] = 'application/xml';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 获取通知公告详情
         * @param {number} id 主键Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeDetailGet: async (id: number, options: any = {}): Promise<RequestArgs> => {
            // verify required parameter 'id' is not null or undefined
            if (id === null || id === undefined) {
                throw new RequiredError('id','Required parameter id was null or undefined when calling sysNoticeDetailGet.');
            }
            const localVarPath = `/sysNotice/detail`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            if (id !== undefined) {
                localVarQueryParameter['Id'] = id;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 更新通知公告
         * @param {UpdateNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeEditPost: async (body?: UpdateNoticeInput, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/edit`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            localVarHeaderParameter['Content-Type'] = 'application/xml';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 分页查询通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticePageGet: async (type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/page`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            if (type !== undefined) {
                localVarQueryParameter['Type'] = type;
            }

            if (searchValue !== undefined) {
                localVarQueryParameter['SearchValue'] = searchValue;
            }

            if (pageNo !== undefined) {
                localVarQueryParameter['PageNo'] = pageNo;
            }

            if (pageSize !== undefined) {
                localVarQueryParameter['PageSize'] = pageSize;
            }

            if (searchBeginTime !== undefined) {
                localVarQueryParameter['SearchBeginTime'] = searchBeginTime;
            }

            if (searchEndTime !== undefined) {
                localVarQueryParameter['SearchEndTime'] = searchEndTime;
            }

            if (sortField !== undefined) {
                localVarQueryParameter['SortField'] = sortField;
            }

            if (sortOrder !== undefined) {
                localVarQueryParameter['SortOrder'] = sortOrder;
            }

            if (descStr !== undefined) {
                localVarQueryParameter['DescStr'] = descStr;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 获取接收的通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeReceivedGet: async (type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysNotice/received`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            if (type !== undefined) {
                localVarQueryParameter['Type'] = type;
            }

            if (searchValue !== undefined) {
                localVarQueryParameter['SearchValue'] = searchValue;
            }

            if (pageNo !== undefined) {
                localVarQueryParameter['PageNo'] = pageNo;
            }

            if (pageSize !== undefined) {
                localVarQueryParameter['PageSize'] = pageSize;
            }

            if (searchBeginTime !== undefined) {
                localVarQueryParameter['SearchBeginTime'] = searchBeginTime;
            }

            if (searchEndTime !== undefined) {
                localVarQueryParameter['SearchEndTime'] = searchEndTime;
            }

            if (sortField !== undefined) {
                localVarQueryParameter['SortField'] = sortField;
            }

            if (sortOrder !== undefined) {
                localVarQueryParameter['SortOrder'] = sortOrder;
            }

            if (descStr !== undefined) {
                localVarQueryParameter['DescStr'] = descStr;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.query) {
                query.set(key, options.query[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * NoticeApi - functional programming interface
 * @export
 */
export const NoticeApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 增加通知公告
         * @param {AddNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeAddPost(body?: AddNoticeInput, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeAddPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 修改通知公告状态
         * @param {ChangeStatusNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeChangeStatusPost(body?: ChangeStatusNoticeInput, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeChangeStatusPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 删除通知公告
         * @param {DeleteNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeDeletePost(body?: DeleteNoticeInput, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeDeletePost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 获取通知公告详情
         * @param {number} id 主键Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeDetailGet(id: number, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<XnRestfulResultOfNoticeDetailOutput>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeDetailGet(id, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 更新通知公告
         * @param {UpdateNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeEditPost(body?: UpdateNoticeInput, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeEditPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 分页查询通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticePageGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<XnRestfulResultOfObject>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticePageGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 获取接收的通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysNoticeReceivedGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<XnRestfulResultOfObject>> {
            const localVarAxiosArgs = await NoticeApiAxiosParamCreator(configuration).sysNoticeReceivedGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * NoticeApi - factory interface
 * @export
 */
export const NoticeApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary 增加通知公告
         * @param {AddNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeAddPost(body?: AddNoticeInput, options?: any): AxiosPromise<void> {
            return NoticeApiFp(configuration).sysNoticeAddPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 修改通知公告状态
         * @param {ChangeStatusNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeChangeStatusPost(body?: ChangeStatusNoticeInput, options?: any): AxiosPromise<void> {
            return NoticeApiFp(configuration).sysNoticeChangeStatusPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 删除通知公告
         * @param {DeleteNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeDeletePost(body?: DeleteNoticeInput, options?: any): AxiosPromise<void> {
            return NoticeApiFp(configuration).sysNoticeDeletePost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 获取通知公告详情
         * @param {number} id 主键Id
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeDetailGet(id: number, options?: any): AxiosPromise<XnRestfulResultOfNoticeDetailOutput> {
            return NoticeApiFp(configuration).sysNoticeDetailGet(id, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 更新通知公告
         * @param {UpdateNoticeInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeEditPost(body?: UpdateNoticeInput, options?: any): AxiosPromise<void> {
            return NoticeApiFp(configuration).sysNoticeEditPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 分页查询通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticePageGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any): AxiosPromise<XnRestfulResultOfObject> {
            return NoticeApiFp(configuration).sysNoticePageGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 获取接收的通知公告
         * @param {number} [type] 类型（字典 1通知 2公告）
         * @param {string} [searchValue] 搜索值
         * @param {number} [pageNo] 当前页码
         * @param {number} [pageSize] 页码容量
         * @param {string} [searchBeginTime] 搜索开始时间
         * @param {string} [searchEndTime] 搜索结束时间
         * @param {string} [sortField] 排序字段
         * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
         * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysNoticeReceivedGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any): AxiosPromise<XnRestfulResultOfObject> {
            return NoticeApiFp(configuration).sysNoticeReceivedGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * NoticeApi - object-oriented interface
 * @export
 * @class NoticeApi
 * @extends {BaseAPI}
 */
export class NoticeApi extends BaseAPI {
    /**
     * 
     * @summary 增加通知公告
     * @param {AddNoticeInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeAddPost(body?: AddNoticeInput, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeAddPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 修改通知公告状态
     * @param {ChangeStatusNoticeInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeChangeStatusPost(body?: ChangeStatusNoticeInput, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeChangeStatusPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 删除通知公告
     * @param {DeleteNoticeInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeDeletePost(body?: DeleteNoticeInput, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeDeletePost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 获取通知公告详情
     * @param {number} id 主键Id
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeDetailGet(id: number, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeDetailGet(id, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 更新通知公告
     * @param {UpdateNoticeInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeEditPost(body?: UpdateNoticeInput, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeEditPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 分页查询通知公告
     * @param {number} [type] 类型（字典 1通知 2公告）
     * @param {string} [searchValue] 搜索值
     * @param {number} [pageNo] 当前页码
     * @param {number} [pageSize] 页码容量
     * @param {string} [searchBeginTime] 搜索开始时间
     * @param {string} [searchEndTime] 搜索结束时间
     * @param {string} [sortField] 排序字段
     * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
     * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticePageGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticePageGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 获取接收的通知公告
     * @param {number} [type] 类型（字典 1通知 2公告）
     * @param {string} [searchValue] 搜索值
     * @param {number} [pageNo] 当前页码
     * @param {number} [pageSize] 页码容量
     * @param {string} [searchBeginTime] 搜索开始时间
     * @param {string} [searchEndTime] 搜索结束时间
     * @param {string} [sortField] 排序字段
     * @param {string} [sortOrder] 排序方法,默认升序,否则降序(配合antd前端,约定参数为 Ascend,Dscend)
     * @param {string} [descStr] 降序排序(不要问我为什么是descend不是desc，前端约定参数就是这样)
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof NoticeApi
     */
    public sysNoticeReceivedGet(type?: number, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any) {
        return NoticeApiFp(this.configuration).sysNoticeReceivedGet(type, searchValue, pageNo, pageSize, searchBeginTime, searchEndTime, sortField, sortOrder, descStr, options).then((request) => request(this.axios, this.basePath));
    }
}
