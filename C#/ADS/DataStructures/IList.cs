namespace ADS.DataStructures
{
    interface IList<T>
    {
        void Purge();
        void InsertAfter( T elem, T after );
        void Append( T elem );
        void Prepend( T elem );
        void Remove( T elem );

        T First();
        T Last();
        T ElementAt(int pos);

        int Count();
    }
}
