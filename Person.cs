class Person
{
    String firstName;
    String lastName;
    DateTime birthday;

    public DateTime Birthday
    {
        get => birthday;
        set
        {
            if (DateTime.Today >= value)
                birthday = value;
            else
                throw new ArgumentException("День рождения не может быть больше сегодняшнего дня");
        }
    }
    public String FirstName
    {
        get => firstName;
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Значение имеет null или пустая строка");

            firstName = value;
        }
    }
    public String LastName
    {
        get => lastName;
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Значение имеет null или пустая строка");

            lastName = value;
        }
    }

    public int Yers
    {
        get => birthday.Year;
        set
        {
            if (value > DateTime.Now.Year)
                throw new ArgumentException("Передаваемый год больше года в данный момент");

            int differenceYers = DateTime.Now.Year - value;

            birthday = birthday.AddYears(-differenceYers);
        }
    }

    public Person()
    {
        this.firstName = "Имя неизвестно";
        this.lastName = "Фамилия неизвестна";
        this.birthday = DateTime.Today;
    }

    public Person(String firstName, String lastName, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
    }

    public override string ToString() => $"Имя: {firstName}; Фамилия: {LastName}; год рождения: {birthday.ToShortDateString()}";

    public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false; Person person = (Person)obj;
        return firstName == person.firstName && lastName == person.lastName && birthday == person.birthday;
    }
    public static bool operator ==(Person a, Person b)
    {
        return a.Equals(b);
    }
    public static bool operator !=(Person a, Person b)
    {
        return !a.Equals(b);
    }
    public override int GetHashCode()
    {
        return firstName.GetHashCode() ^ lastName.GetHashCode() ^ birthday.GetHashCode();
    }
    public Person DeepCopy()
    {
        return new Person(firstName, lastName, birthday);
    }
}
