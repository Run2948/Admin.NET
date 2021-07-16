﻿using Furion;
using Furion.DependencyInjection;
using Furion.JsonSerialization;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Yitter.IdGenerator;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 点选验证码
    /// </summary>
    public class ClickWordCaptcha : IClickWordCaptcha, ITransient
    {
        private readonly IMemoryCache _memoryCache;

        public ClickWordCaptcha(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="code"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ClickWordCaptchaResult CreateCaptchaImage(string code, int width, int height)
        {
            var rtnResult = new ClickWordCaptchaResult();

            // 变化点: 3个字
            int rightCodeLength = 3;

            Bitmap bitmap = null;
            Graphics g = null;
            MemoryStream ms = null;
            Random random = new();

            Color[] colorArray = { Color.Black, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            string bgImagesDir = Path.Combine(App.WebHostEnvironment.WebRootPath, "Captcha/Image");
            string[] bgImagesFiles = Directory.GetFiles(bgImagesDir);

            // 字体来自：https://www.zcool.com.cn/special/zcoolfonts/
            string fontsDir = Path.Combine(App.WebHostEnvironment.WebRootPath, "Captcha/Font");
            string[] fontFiles = new DirectoryInfo(fontsDir)?.GetFiles()
                ?.Where(m => m.Extension.ToLower() == ".ttf")
                ?.Select(m => m.FullName).ToArray();

            int imgIndex = random.Next(bgImagesFiles.Length);
            string randomImgFile = bgImagesFiles[imgIndex];
            var imageStream = Image.FromFile(randomImgFile);

            bitmap = new Bitmap(imageStream, width, height);
            imageStream.Dispose();
            g = Graphics.FromImage(bitmap);
            Color[] penColor = { Color.Red, Color.Green, Color.Blue };
            int code_length = code.Length;
            var words = new List<string>();
            for (int i = 0; i < code_length; i++)
            {
                int colorIndex = random.Next(colorArray.Length);
                int fontIndex = random.Next(fontFiles.Length);
                Font f = LoadFont(fontFiles[fontIndex], 18, FontStyle.Regular);
                Brush b = new SolidBrush(colorArray[colorIndex]);
                int _y = random.Next(height);
                if (_y > (height - 30))
                    _y -= 60;

                int _x = width / (i + 1);
                if ((width - _x) < 50)
                {
                    _x = width - 60;
                }
                string word = code.Substring(i, 1);
                if (rtnResult.RepData.Point.Count < rightCodeLength)
                {
                    // (int, int) percentPos = ToPercentPos((width, height), (_x, _y));
                    // 添加正确答案 位置数据
                    if (random.Next(0, 3).Equals(1) || (code_length - i).Equals(rightCodeLength - rtnResult.RepData.Point.Count))
                    {
                        rtnResult.RepData.Point.Add(new PointPosModel()
                        {
                            X = _x, //percentPos.Item1,
                            Y = _y  //percentPos.Item2,
                        });
                        words.Add(word);
                    }
                }
                g.DrawString(word, f, b, _x, _y);
            }
            rtnResult.RepData.WordList = words;

            ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            g.Dispose();
            bitmap.Dispose();
            ms.Dispose();
            rtnResult.RepData.OriginalImageBase64 = Convert.ToBase64String(ms.GetBuffer()); //"data:image/jpg;base64," +
            rtnResult.RepData.Token = YitIdHelper.NextId().ToString();

            // 缓存验证码正确位置集合
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            _memoryCache.Set(CommonConst.CACHE_KEY_CODE + rtnResult.RepData.Token, rtnResult.RepData.Point, cacheOptions);

            rtnResult.RepData.Point = null; // 清空位置信息
            return rtnResult;
        }

        ///// <summary>
        ///// 转换为相对于图片的百分比单位
        ///// </summary>
        ///// <param name="widthAndHeight">图片宽高</param>
        ///// <param name="xAndy">相对于图片的绝对尺寸</param>
        ///// <returns>(int:xPercent, int:yPercent)</returns>
        //private static (int, int) ToPercentPos((int, int) widthAndHeight, (int, int) xAndy)
        //{
        //    (int, int) rtnResult = (0, 0);
        //    // 注意: int / int = int (小数部分会被截断)
        //    rtnResult.Item1 = (int)(((double)xAndy.Item1) / ((double)widthAndHeight.Item1) * 100);
        //    rtnResult.Item2 = (int)(((double)xAndy.Item2) / ((double)widthAndHeight.Item2) * 100);

        //    return rtnResult;
        //}

        /// <summary>
        /// 加载字体
        /// </summary>
        /// <param name="path">字体文件路径,包含字体文件名和后缀名</param>
        /// <param name="size">大小</param>
        /// <param name="fontStyle">字形(常规/粗体/斜体/粗斜体)</param>
        private static Font LoadFont(string path, int size, FontStyle fontStyle)
        {
            var pfc = new System.Drawing.Text.PrivateFontCollection();
            pfc.AddFontFile(path);// 字体文件路径
            return new Font(pfc.Families[0], size, fontStyle);
        }

        /// <summary>
        /// 随机绘制字符串
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string RandomCode(int number)
        {
            char[] str_char_arrary = new char[] { '赵', '钱', '孙', '李', '周', '吴', '郑', '王', '冯', '陈', '褚', '卫', '蒋', '沈', '韩', '杨',
                '朱', '秦', '尤', '许', '何', '吕', '施', '张', '孔', '曹', '严', '华', '金', '魏', '陶', '姜', '戚', '谢', '邹', '喻', '柏', '水',
                '窦', '章', '云', '苏', '潘', '葛', '奚', '范', '彭', '郎', '鲁', '韦', '昌', '马', '苗', '凤', '花', '方', '任', '袁', '柳', '鲍',
                '史', '唐', '费', '薛', '雷', '贺', '倪', '汤', '滕', '殷', '罗', '毕', '郝', '安', '常', '傅', '卞', '齐', '元', '顾', '孟', '平',
                '黄', '穆', '萧', '尹', '姚', '邵', '湛', '汪', '祁', '毛', '狄', '米', '伏', '成', '戴', '谈', '宋', '茅', '庞', '熊', '纪', '舒',
                '屈', '项', '祝', '董', '梁', '杜', '阮', '蓝', '闵', '季', '贾', '路', '娄', '江', '童', '颜', '郭', '梅', '盛', '林', '钟', '徐',
                '邱', '骆', '高', '夏', '蔡', '田', '樊', '胡', '凌', '霍', '虞', '万', '支', '柯', '管', '卢', '莫', '柯', '房', '裘', '缪', '解',
                '应', '宗', '丁', '宣', '邓', '单', '杭', '洪', '包', '诸', '左', '石', '崔', '吉', '龚', '程', '嵇', '邢', '裴', '陆', '荣', '翁',
                '荀', '于', '惠', '甄', '曲', '封', '储', '仲', '伊', '宁', '仇', '甘', '武', '符', '刘', '景', '詹', '龙', '叶', '幸', '司', '黎',
                '溥', '印', '怀', '蒲', '邰', '从', '索', '赖', '卓', '屠', '池', '乔', '胥', '闻', '莘', '党', '翟', '谭', '贡', '劳', '逄', '姬',
                '申', '扶', '堵', '冉', '宰', '雍', '桑', '寿', '通', '燕', '浦', '尚', '农', '温', '别', '庄', '晏', '柴', '瞿', '阎', '连', '习',
                '容', '向', '古', '易', '廖', '庾', '终', '步', '都', '耿', '满', '弘', '匡', '国', '文', '寇', '广', '禄', '阙', '东', '欧', '利',
                '师', '巩', '聂', '关', '荆',
                '伟', '刚', '勇', '毅', '俊', '峰', '强', '军', '平', '保', '东', '文', '辉', '力', '明', '永', '健', '世', '广', '志', '义', '兴',
                '良', '海', '山', '仁', '波', '宁', '贵', '福', '生', '龙', '元', '全', '国', '胜', '学', '祥', '才', '发', '武', '新', '利', '清',
                '飞', '彬', '富', '顺', '信', '子', '杰', '涛', '昌', '成', '康', '星', '光', '天', '达', '安', '岩', '中', '茂', '进', '林', '有',
                '坚', '和', '彪', '博', '诚', '先', '敬', '震', '振', '壮', '会', '思', '群', '豪', '心', '邦', '承', '乐', '绍', '功', '松', '善',
                '厚', '庆', '磊', '民', '友', '裕', '河', '哲', '江', '超', '浩', '亮', '政', '谦', '亨', '奇', '固', '之', '轮', '翰', '朗', '伯',
                '宏', '言', '若', '鸣', '朋', '斌', '梁', '栋', '维', '启', '克', '伦', '翔', '旭', '鹏', '泽', '晨', '辰', '士', '以', '建', '家',
                '致', '树', '炎', '德', '行', '时', '泰', '盛', '雄', '琛', '钧', '冠', '策', '腾', '楠', '榕', '风', '航', '弘', '秀', '娟', '英',
                '华', '慧', '巧', '美', '娜', '静', '淑', '惠', '珠', '翠', '雅', '芝', '玉', '萍', '红', '娥', '玲', '芬', '芳', '燕', '彩', '春',
                '菊', '兰', '凤', '洁', '梅', '琳', '素', '云', '莲', '真', '环', '雪', '荣', '爱', '妹', '霞', '香', '月', '莺', '媛', '艳', '瑞',
                '凡', '佳', '嘉', '琼', '勤', '珍', '贞', '莉', '桂', '娣', '叶', '璧', '璐', '娅', '琦', '晶', '妍', '茜', '秋', '珊', '莎', '锦',
                '黛', '青', '倩', '婷', '姣', '婉', '娴', '瑾', '颖', '露', '瑶', '怡', '婵', '雁', '蓓', '纨', '仪', '荷', '丹', '蓉', '眉', '君',
                '琴', '蕊', '薇', '菁', '梦', '岚', '苑', '婕', '馨', '瑗', '琰', '韵', '融', '园', '艺', '咏', '卿', '聪', '澜', '纯', '毓', '悦',
                '昭', '冰', '爽', '琬', '茗', '羽', '希', '欣', '飘', '育', '滢', '馥', '筠', '柔', '竹', '霭', '凝', '晓', '欢', '霄', '枫', '芸',
                '菲', '寒', '伊', '亚', '宜', '可', '姬', '舒', '影', '荔', '枝', '丽', '阳', '妮', '宝', '贝', '初', '程', '梵', '罡', '恒', '鸿',
                '桦', '骅', '剑', '娇', '纪', '宽', '苛', '灵', '玛', '媚', '琪', '晴', '容', '睿', '烁', '堂', '唯', '威', '韦', '雯', '苇', '萱',
                '阅', '彦', '宇', '雨', '洋', '忠', '宗', '曼', '紫', '逸', '贤', '蝶', '菡', '绿', '蓝', '儿', '翠', '烟' };
            var rand = new Random();
            var hs = new HashSet<char>();
            var randomBool = true;
            while (randomBool)
            {
                if (hs.Count == number)
                    break;
                var rand_number = rand.Next(str_char_arrary.Length);
                hs.Add(str_char_arrary[rand_number]);
            }
            return string.Join("", hs);
        }

        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic CheckCode(ClickWordCaptchaInput input)
        {
            var res = new ClickWordCaptchaResult();

            var rightVCodePos = _memoryCache.Get(CommonConst.CACHE_KEY_CODE + input.Token) as List<PointPosModel>;
            if (rightVCodePos == null)
            {
                res.RepCode = "6110";
                res.RepMsg = "验证码已失效，请重新获取";
                return res;
            }

            var userVCodePos = JSON.Deserialize<List<PointPosModel>>(input.PointJson);
            if (userVCodePos == null || userVCodePos.Count < rightVCodePos.Count)
            {
                res.RepCode = "6111";
                res.RepMsg = "验证码无效";
                return res;
            }

            int allowOffset = 25; // 允许的偏移量(点触容错)
            for (int i = 0; i < userVCodePos.Count; i++)
            {
                var xOffset = userVCodePos[i].X - rightVCodePos[i].X;
                var yOffset = userVCodePos[i].Y - rightVCodePos[i].Y;
                xOffset = Math.Abs(xOffset); // x轴偏移量
                yOffset = Math.Abs(yOffset); // y轴偏移量
                // 只要有一个点的任意一个轴偏移量大于allowOffset，则验证不通过
                if (xOffset > allowOffset || yOffset > allowOffset)
                {
                    res.RepCode = "6112";
                    res.RepMsg = "验证码错误";
                    return res;
                }
            }

            _memoryCache.Remove(CommonConst.CACHE_KEY_CODE + input.Token);
            res.RepCode = "0000";
            res.RepMsg = "验证成功";
            return res;
        }
    }

    /// <summary>
    /// 记录正确位置
    /// </summary>
    public class PointPosModel
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}