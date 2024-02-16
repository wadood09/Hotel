class Chemistry : ITest
{
  public double Questions(User user)
  {
    Console.WriteLine("NOTE: FILL IN THE CORRECT ANSWERS");
    Console.WriteLine("Chemistry");
    Console.WriteLine();
    Console.WriteLine("Question 1:Chemistry is The study of ______?");
    Console.WriteLine("Options   A:Animal B:Matter C:Plant");
    string chemOneAns = Console.ReadLine();
    if (chemOneAns.ToUpper() == "B") ;
    {
      user.ChemistryScore++;
    }
    Console.WriteLine();
    Console.WriteLine("Question 2:_____is the smallest recognized chemical element");
    Console.WriteLine("Options   A:Atom B:Dust C:Seed");
    string chemTwoAns = Console.ReadLine();
    if (chemTwoAns.ToUpper() == "A")
    {
      user.ChemistryScore++;
    }
    Console.WriteLine();
    Console.WriteLine("Question 3:The S I unit of temperature is________?");
    Console.WriteLine("Options   A:Seconds B:Kelvin C:Length");
    string chemThreeAns = Console.ReadLine();
    if (chemThreeAns.ToUpper() == "B")
    {
      user.ChemistryScore++;
    }
    Console.WriteLine();
    Console.WriteLine("Question 4:Amino Acids are obtained from proteins by_______?");
    Console.WriteLine("Options   A:Hydrolysis B:Crystallization C:Beans");
    string chemFourAns = Console.ReadLine();
    if (chemFourAns.ToUpper() == "A")
    {
      user.ChemistryScore++;
    }
    Console.WriteLine();
    Console.WriteLine("Question 5: Ripening of fruit is hastened by ______?");
    Console.WriteLine("Options   A:Photosynthesis B:Ethyne C:Ethene");
    string chemFiveAns = Console.ReadLine();
    if (chemFiveAns.ToUpper() == "C")
    {
      user.ChemistryScore++;
    }
    Console.WriteLine();
    return user.ChemistryScore;

  }
}
