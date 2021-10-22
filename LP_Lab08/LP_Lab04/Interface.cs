namespace LP_Lab04
{
    interface IGenericInterf<T>
    {
        void Add(T aitem,int index);
        void Del(T aitem);
        void Show();
    }
}