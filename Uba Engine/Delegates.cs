namespace Uba_Engine
{
    public delegate void SpriteUpdate(Sprite s);

    public delegate void LimitHit(LimitObject limitObject);

    public delegate void StateChanger();

    public delegate void SetupDelegate();

    public delegate void EventHandler();

    public delegate void Animation();

    public delegate void MenuItemSelect(Text text);

    public delegate void TextSelect();
    /// <summary>
    /// A delegate to read a type from the file. 
    /// 
    /// 
    /// e.g.
    ///public void ReadObject(Reader reader, Object obj)
    ///{
    ///    if (reader.ReadPossible)
    ///    {
    ///        reader.Serializer = new XmlSerializer(typeof(Object));
    ///        obj = (SaveContainer)reader.Serializer.Deserialize(reader.sr);
    ///        reader.sr.Close();
    ///    }
    ///    else obj = new Object();
    ///}
    /// </summary>
    /// <param name="r"> The reader to use with serialiser and stream</param>
    public delegate void ReadDelegate(Reader r, object obj);
}
