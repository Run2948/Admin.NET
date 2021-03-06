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
import { CodeGenConfig } from '../models';
import { XnRestfulResultOfListOfCodeGenConfig } from '../models';
import { XnRestfulResultOfSysCodeGenConfig } from '../models';
/**
 * CodegenconfigApi - axios parameter creator
 * @export
 */
export const CodegenconfigApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 详情
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigDetailGet: async (id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysCodeGenerateConfig/detail`;
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

            if (codeGenId !== undefined) {
                localVarQueryParameter['CodeGenId'] = codeGenId;
            }

            if (columnName !== undefined) {
                localVarQueryParameter['ColumnName'] = columnName;
            }

            if (lowerColumnName !== undefined) {
                localVarQueryParameter['LowerColumnName'] = lowerColumnName;
            }

            if (columnComment !== undefined) {
                localVarQueryParameter['ColumnComment'] = columnComment;
            }

            if (netType !== undefined) {
                localVarQueryParameter['NetType'] = netType;
            }

            if (effectType !== undefined) {
                localVarQueryParameter['EffectType'] = effectType;
            }

            if (fkEntityName !== undefined) {
                localVarQueryParameter['FkEntityName'] = fkEntityName;
            }

            if (lowerFkEntityName !== undefined) {
                localVarQueryParameter['LowerFkEntityName'] = lowerFkEntityName;
            }

            if (fkColumnName !== undefined) {
                localVarQueryParameter['FkColumnName'] = fkColumnName;
            }

            if (lowerFkColumnName !== undefined) {
                localVarQueryParameter['LowerFkColumnName'] = lowerFkColumnName;
            }

            if (fkColumnNetType !== undefined) {
                localVarQueryParameter['FkColumnNetType'] = fkColumnNetType;
            }

            if (dictTypeCode !== undefined) {
                localVarQueryParameter['DictTypeCode'] = dictTypeCode;
            }

            if (whetherRetract !== undefined) {
                localVarQueryParameter['WhetherRetract'] = whetherRetract;
            }

            if (whetherRequired !== undefined) {
                localVarQueryParameter['WhetherRequired'] = whetherRequired;
            }

            if (queryWhether !== undefined) {
                localVarQueryParameter['QueryWhether'] = queryWhether;
            }

            if (queryType !== undefined) {
                localVarQueryParameter['QueryType'] = queryType;
            }

            if (whetherTable !== undefined) {
                localVarQueryParameter['WhetherTable'] = whetherTable;
            }

            if (whetherOrderBy !== undefined) {
                localVarQueryParameter['WhetherOrderBy'] = whetherOrderBy;
            }

            if (whetherAddUpdate !== undefined) {
                localVarQueryParameter['WhetherAddUpdate'] = whetherAddUpdate;
            }

            if (columnKey !== undefined) {
                localVarQueryParameter['ColumnKey'] = columnKey;
            }

            if (dataType !== undefined) {
                localVarQueryParameter['DataType'] = dataType;
            }

            if (whetherCommon !== undefined) {
                localVarQueryParameter['WhetherCommon'] = whetherCommon;
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
         * @summary 更新
         * @param {Array&lt;CodeGenConfig&gt;} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigEditPost: async (body?: Array<CodeGenConfig>, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysCodeGenerateConfig/edit`;
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
         * @summary 代码生成详细配置列表
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigListGet: async (id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysCodeGenerateConfig/list`;
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

            if (codeGenId !== undefined) {
                localVarQueryParameter['CodeGenId'] = codeGenId;
            }

            if (columnName !== undefined) {
                localVarQueryParameter['ColumnName'] = columnName;
            }

            if (lowerColumnName !== undefined) {
                localVarQueryParameter['LowerColumnName'] = lowerColumnName;
            }

            if (columnComment !== undefined) {
                localVarQueryParameter['ColumnComment'] = columnComment;
            }

            if (netType !== undefined) {
                localVarQueryParameter['NetType'] = netType;
            }

            if (effectType !== undefined) {
                localVarQueryParameter['EffectType'] = effectType;
            }

            if (fkEntityName !== undefined) {
                localVarQueryParameter['FkEntityName'] = fkEntityName;
            }

            if (lowerFkEntityName !== undefined) {
                localVarQueryParameter['LowerFkEntityName'] = lowerFkEntityName;
            }

            if (fkColumnName !== undefined) {
                localVarQueryParameter['FkColumnName'] = fkColumnName;
            }

            if (lowerFkColumnName !== undefined) {
                localVarQueryParameter['LowerFkColumnName'] = lowerFkColumnName;
            }

            if (fkColumnNetType !== undefined) {
                localVarQueryParameter['FkColumnNetType'] = fkColumnNetType;
            }

            if (dictTypeCode !== undefined) {
                localVarQueryParameter['DictTypeCode'] = dictTypeCode;
            }

            if (whetherRetract !== undefined) {
                localVarQueryParameter['WhetherRetract'] = whetherRetract;
            }

            if (whetherRequired !== undefined) {
                localVarQueryParameter['WhetherRequired'] = whetherRequired;
            }

            if (queryWhether !== undefined) {
                localVarQueryParameter['QueryWhether'] = queryWhether;
            }

            if (queryType !== undefined) {
                localVarQueryParameter['QueryType'] = queryType;
            }

            if (whetherTable !== undefined) {
                localVarQueryParameter['WhetherTable'] = whetherTable;
            }

            if (whetherOrderBy !== undefined) {
                localVarQueryParameter['WhetherOrderBy'] = whetherOrderBy;
            }

            if (whetherAddUpdate !== undefined) {
                localVarQueryParameter['WhetherAddUpdate'] = whetherAddUpdate;
            }

            if (columnKey !== undefined) {
                localVarQueryParameter['ColumnKey'] = columnKey;
            }

            if (dataType !== undefined) {
                localVarQueryParameter['DataType'] = dataType;
            }

            if (whetherCommon !== undefined) {
                localVarQueryParameter['WhetherCommon'] = whetherCommon;
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
 * CodegenconfigApi - functional programming interface
 * @export
 */
export const CodegenconfigApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 详情
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysCodeGenerateConfigDetailGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<XnRestfulResultOfSysCodeGenConfig>> {
            const localVarAxiosArgs = await CodegenconfigApiAxiosParamCreator(configuration).sysCodeGenerateConfigDetailGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 更新
         * @param {Array&lt;CodeGenConfig&gt;} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysCodeGenerateConfigEditPost(body?: Array<CodeGenConfig>, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await CodegenconfigApiAxiosParamCreator(configuration).sysCodeGenerateConfigEditPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 代码生成详细配置列表
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysCodeGenerateConfigListGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<XnRestfulResultOfListOfCodeGenConfig>> {
            const localVarAxiosArgs = await CodegenconfigApiAxiosParamCreator(configuration).sysCodeGenerateConfigListGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * CodegenconfigApi - factory interface
 * @export
 */
export const CodegenconfigApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary 详情
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigDetailGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any): AxiosPromise<XnRestfulResultOfSysCodeGenConfig> {
            return CodegenconfigApiFp(configuration).sysCodeGenerateConfigDetailGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 更新
         * @param {Array&lt;CodeGenConfig&gt;} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigEditPost(body?: Array<CodeGenConfig>, options?: any): AxiosPromise<void> {
            return CodegenconfigApiFp(configuration).sysCodeGenerateConfigEditPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 代码生成详细配置列表
         * @param {number} [id] 主键Id
         * @param {number} [codeGenId] 代码生成主表ID
         * @param {string} [columnName] 数据库字段名
         * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
         * @param {string} [columnComment] 字段描述
         * @param {string} [netType] .NET类型
         * @param {string} [effectType] 作用类型（字典）
         * @param {string} [fkEntityName] 外键实体名称
         * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
         * @param {string} [fkColumnName] 外键显示字段
         * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
         * @param {string} [fkColumnNetType] 外键显示字段.NET类型
         * @param {string} [dictTypeCode] 字典code
         * @param {string} [whetherRetract] 列表是否缩进（字典）
         * @param {string} [whetherRequired] 是否必填（字典）
         * @param {string} [queryWhether] 是否是查询条件
         * @param {string} [queryType] 查询方式
         * @param {string} [whetherTable] 列表显示
         * @param {string} [whetherOrderBy] 列表排序显示
         * @param {string} [whetherAddUpdate] 增改
         * @param {string} [columnKey] 主外键
         * @param {string} [dataType] 数据库中类型（物理类型）
         * @param {string} [whetherCommon] 是否是通用字段
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysCodeGenerateConfigListGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any): AxiosPromise<XnRestfulResultOfListOfCodeGenConfig> {
            return CodegenconfigApiFp(configuration).sysCodeGenerateConfigListGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * CodegenconfigApi - object-oriented interface
 * @export
 * @class CodegenconfigApi
 * @extends {BaseAPI}
 */
export class CodegenconfigApi extends BaseAPI {
    /**
     * 
     * @summary 详情
     * @param {number} [id] 主键Id
     * @param {number} [codeGenId] 代码生成主表ID
     * @param {string} [columnName] 数据库字段名
     * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
     * @param {string} [columnComment] 字段描述
     * @param {string} [netType] .NET类型
     * @param {string} [effectType] 作用类型（字典）
     * @param {string} [fkEntityName] 外键实体名称
     * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
     * @param {string} [fkColumnName] 外键显示字段
     * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
     * @param {string} [fkColumnNetType] 外键显示字段.NET类型
     * @param {string} [dictTypeCode] 字典code
     * @param {string} [whetherRetract] 列表是否缩进（字典）
     * @param {string} [whetherRequired] 是否必填（字典）
     * @param {string} [queryWhether] 是否是查询条件
     * @param {string} [queryType] 查询方式
     * @param {string} [whetherTable] 列表显示
     * @param {string} [whetherOrderBy] 列表排序显示
     * @param {string} [whetherAddUpdate] 增改
     * @param {string} [columnKey] 主外键
     * @param {string} [dataType] 数据库中类型（物理类型）
     * @param {string} [whetherCommon] 是否是通用字段
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CodegenconfigApi
     */
    public sysCodeGenerateConfigDetailGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any) {
        return CodegenconfigApiFp(this.configuration).sysCodeGenerateConfigDetailGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 更新
     * @param {Array&lt;CodeGenConfig&gt;} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CodegenconfigApi
     */
    public sysCodeGenerateConfigEditPost(body?: Array<CodeGenConfig>, options?: any) {
        return CodegenconfigApiFp(this.configuration).sysCodeGenerateConfigEditPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 代码生成详细配置列表
     * @param {number} [id] 主键Id
     * @param {number} [codeGenId] 代码生成主表ID
     * @param {string} [columnName] 数据库字段名
     * @param {string} [lowerColumnName] 数据库字段名(首字母小写)
     * @param {string} [columnComment] 字段描述
     * @param {string} [netType] .NET类型
     * @param {string} [effectType] 作用类型（字典）
     * @param {string} [fkEntityName] 外键实体名称
     * @param {string} [lowerFkEntityName] 外键实体名称(首字母小写)
     * @param {string} [fkColumnName] 外键显示字段
     * @param {string} [lowerFkColumnName] 外键显示字段(首字母小写)
     * @param {string} [fkColumnNetType] 外键显示字段.NET类型
     * @param {string} [dictTypeCode] 字典code
     * @param {string} [whetherRetract] 列表是否缩进（字典）
     * @param {string} [whetherRequired] 是否必填（字典）
     * @param {string} [queryWhether] 是否是查询条件
     * @param {string} [queryType] 查询方式
     * @param {string} [whetherTable] 列表显示
     * @param {string} [whetherOrderBy] 列表排序显示
     * @param {string} [whetherAddUpdate] 增改
     * @param {string} [columnKey] 主外键
     * @param {string} [dataType] 数据库中类型（物理类型）
     * @param {string} [whetherCommon] 是否是通用字段
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CodegenconfigApi
     */
    public sysCodeGenerateConfigListGet(id?: number, codeGenId?: number, columnName?: string, lowerColumnName?: string, columnComment?: string, netType?: string, effectType?: string, fkEntityName?: string, lowerFkEntityName?: string, fkColumnName?: string, lowerFkColumnName?: string, fkColumnNetType?: string, dictTypeCode?: string, whetherRetract?: string, whetherRequired?: string, queryWhether?: string, queryType?: string, whetherTable?: string, whetherOrderBy?: string, whetherAddUpdate?: string, columnKey?: string, dataType?: string, whetherCommon?: string, options?: any) {
        return CodegenconfigApiFp(this.configuration).sysCodeGenerateConfigListGet(id, codeGenId, columnName, lowerColumnName, columnComment, netType, effectType, fkEntityName, lowerFkEntityName, fkColumnName, lowerFkColumnName, fkColumnNetType, dictTypeCode, whetherRetract, whetherRequired, queryWhether, queryType, whetherTable, whetherOrderBy, whetherAddUpdate, columnKey, dataType, whetherCommon, options).then((request) => request(this.axios, this.basePath));
    }
}
