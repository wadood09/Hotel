class Biology : ITest
{
  public double Questions(User user)
  {


    Console.WriteLine("Biology");
    Console.WriteLine();
    Console.WriteLine("Question 1:Biology is the Scientific Study of?");
    Console.WriteLine("Options   A:Animal B:Life C:Plant");
    string bioOneChoice = Console.ReadLine();
    if (bioOneChoice.ToUpper() == "B")
    {
      user.BiologyScore++;
    }
    Console.WriteLine();

    Console.WriteLine("Question 2:Biology can aslo be the study of?");
    Console.WriteLine("Options   A:Living Things B:Life C:Herbs");
    string bioTwoChoice = Console.ReadLine();
    if (bioTwoChoice.ToUpper() == "A")
    {
      user.BiologyScore++;
    }
    Console.WriteLine();

    Console.WriteLine("Question 3:What is the biological habitat of a Fish?");
    Console.WriteLine("Options   A:Aboreal Habitat B:Terrestial Habitat C:Aquatic Habitat");
    string bioThreeChoice = Console.ReadLine();
    if (bioThreeChoice.ToUpper() == "C")
    {
      user.BiologyScore++;
    }
    Console.WriteLine();

    Console.WriteLine("Question 4:An Organism which depends on other organisms to live is called?");
    Console.WriteLine("Options   A:Parasite B:Prey C:Pest");
    string bioFourChoice = Console.ReadLine();
    if (bioFourChoice.ToUpper() == "A")
    {
      user.BiologyScore++;
    }
    Console.WriteLine();

    Console.WriteLine("Question 5:What blood cells are responsible for clotting?");
    Console.WriteLine("Options   A:Red blood cells B:White Blood cells C:Plateletes");
    string bioFiveChoice = Console.ReadLine();
    if (bioFiveChoice.ToUpper() == "C")
    {
      user.BiologyScore++;
    }
    Console.WriteLine();
    Console.WriteLine("YOU HAVE SUCCESSFULLY PARTICIPATED IN THE EXAM");
    return user.BiologyScore;
  }
}