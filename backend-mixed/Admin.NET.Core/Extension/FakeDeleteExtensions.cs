using Furion.DatabaseAccessor.Extensions;
using System;
using System.Threading.Tasks;

namespace Furion.DatabaseAccessor
{
    public static class FakeDeleteExtensions
    {
        /// <summary>
        /// ��������
        /// </summary>
        private static string PrimaryKeyName { get; set; } = "Id";
        /// <summary>
        /// ��ɾ������
        /// </summary>
        private static string FakeDeleteColumnName { get; set; } = "IsDeleted";
        /// <summary>
        /// ��ɾ��������idɾ��
        /// </summary>
        public static void FakeDelete<TEntity>(this IPrivateRepository<TEntity> repository,int id)
            where TEntity : class, IPrivateEntity, new()
        {
            // ����ʵ�������������ֵ
            var entity = Activator.CreateInstance<TEntity>();
            var PrimaryKeyProperty = typeof(TEntity).GetProperty(PrimaryKeyName);
            PrimaryKeyProperty.SetValue(PrimaryKeyName, id);
            repository.FakeDelete(entity);
        }
        /// <summary>
        /// ��ɾ��
        /// </summary>
        public static void FakeDelete<TEntity>(this IPrivateRepository<TEntity> repository,TEntity entity)
            where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty= repository.EntityType.ClrType.GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
            repository.UpdateInclude(entity, new[] { fakedeleteProperty.Name });
        }

        /// <summary>
        /// ��ɾ������ִ�У�����idɾ��
        /// </summary>
        public static void FakeDeleteNow<TEntity>(this IPrivateRepository<TEntity> repository, int id)
           where TEntity : class, IPrivateEntity, new()
        {
            // ����ʵ�������������ֵ
            var entity = Activator.CreateInstance<TEntity>();
            var PrimaryKeyProperty = typeof(TEntity).GetProperty(PrimaryKeyName);
            PrimaryKeyProperty.SetValue(PrimaryKeyName, id);
            repository.FakeDeleteNow(entity);
        }
        /// <summary>
        /// ��ɾ������ִ��
        /// </summary>
        public static void FakeDeleteNow<TEntity>(this IPrivateRepository<TEntity> repository, TEntity entity)
            where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = repository.EntityType.ClrType.GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
            repository.UpdateIncludeNow(entity, new[] { fakedeleteProperty.Name });
        }
        /// <summary>
        /// �첽��ɾ��
        /// </summary>

        public static async Task FakeDeleteAsync<TEntity>(this IPrivateRepository<TEntity> repository, int id)
           where TEntity : class, IPrivateEntity, new()
        {
            // ����ʵ�������������ֵ
            var entity = Activator.CreateInstance<TEntity>();
            var PrimaryKeyProperty = typeof(TEntity).GetProperty(PrimaryKeyName);
            PrimaryKeyProperty.SetValue(PrimaryKeyName, id);
            await repository.FakeDeleteAsync(entity);
        }
        /// <summary>
        /// �첽��ɾ��
        /// </summary>
        public static async Task FakeDeleteAsync<TEntity>(this IPrivateRepository<TEntity> repository, TEntity entity)
            where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = repository.EntityType.ClrType.GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
            await repository.UpdateIncludeAsync(entity, new[] { fakedeleteProperty.Name });
        }



        //��չ��entity�ϵļ�ɾ��

        /// <summary>
        /// �첽��ɾ��
        /// </summary>
        public static async Task FakeDeleteAsync<TEntity>(this TEntity entity)
            where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = typeof(TEntity).GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
            await entity.UpdateIncludeAsync(new[] { fakedeleteProperty.Name });
        }
        /// <summary>
        /// �첽��ɾ��������ִ��
        /// </summary>
        public static async Task FakeDeleteNowAsync<TEntity>(this TEntity entity)
          where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = typeof(TEntity).GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
            await entity.UpdateIncludeNowAsync(new[] { fakedeleteProperty.Name });
        }
        /// <summary>
        /// ��ɾ��
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public static void  FakeDelete<TEntity>(this TEntity entity)
           where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = typeof(TEntity).GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
             entity.UpdateInclude(new[] { fakedeleteProperty.Name });
        }
        /// <summary>
        /// ��ɾ������ִ��
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public static void FakeDeleteNow<TEntity>(this TEntity entity)
          where TEntity : class, IPrivateEntity, new()
        {
            var fakedeleteProperty = typeof(TEntity).GetProperty(FakeDeleteColumnName);
            fakedeleteProperty.SetValue(entity, true);
             entity.UpdateIncludeNow(new[] { fakedeleteProperty.Name });
        }
    }
}