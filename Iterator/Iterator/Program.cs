using System;

using System.Collections;

public class AnimalStudent

{
    private readonly string _id;
    private string _firstname;
    private string _lastname;

    public string ID { get { return _id; } }

    public string Firstname
    {
        get { return _firstname; }
        set { _firstname = value; }
    }

    public string Lastname
    {
        get { return _lastname; }
        set { _lastname = value; }
    }

    public AnimalStudent(string id, string firstname, string lastname)
    {
        _id = id;
        _firstname = firstname;
        _lastname = lastname;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}, ID: {2}", _firstname, _lastname, _id);
    }
}

public class ClassList : IEnumerable
{
    private readonly string _id;
    private ArrayList _students;

    public string ID { get { return _id; } }
    public int TotalStudents { get { return _students.Count; } }

    public ClassList(string id)
    {
        _id = id;
        _students = new ArrayList();

        _students.Add(new AnimalStudent("14", "Dominic", "Kozielny"));
        _students.Add(new AnimalStudent("17", "Waldo", "Durson"));
        _students.Add(new AnimalStudent("42", "Bob", "Stone"));
    }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)new ClassEnumerator(this);
    }

    private class ClassEnumerator : IEnumerator
    {
        private ClassList _classList;
        private int _index;

        public ClassEnumerator(ClassList classList)
        {
            _classList = classList;
            _index = -1;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current
        {
            get
            {
                return _classList._students[_index];
            }
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _classList._students.Count)
                return false;
            else
                return true;
        }
    }
}

public class MyClass
{
    public static void Main()
    {
        ClassList myClass = new ClassList("Animal Class");

        Console.WriteLine("Class: {0}, Total Animal Students: {1}\n",

            myClass.ID, myClass.TotalStudents.ToString());

        foreach (AnimalStudent student in myClass)
            Console.WriteLine(student);

        Console.ReadLine();
    }
}