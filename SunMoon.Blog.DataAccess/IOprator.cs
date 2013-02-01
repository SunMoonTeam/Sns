namespace SunMoon.Blog.DataAccess {
    /// <summary>
    /// 基本操作接口
    /// </summary>
    public interface IOprator {

        void Add<T>(T t);

        void Update<T>(T t);

        void Delete<K>(K k);
    }
}