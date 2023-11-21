//MealFactory
using System;
using System.Collections.Generic;

public class Meal
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void Display()
    {
        Console.WriteLine("Meal items:");
        foreach (var item in items)
        {
            Console.WriteLine("- " + item);
        }
    }
}

public interface IMealBuilder
{
    void BuildMainCourse();
    void BuildSide();
    void BuildDrink();
    Meal GetMeal();
}

public class HealthyMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.AddItem("Grilled Chicken Salad");
    }

    public void BuildSide()
    {
        meal.AddItem("Steamed Vegetables");
    }

    public void BuildDrink()
    {
        meal.AddItem("Water");
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

public class FastFoodMealBuilder : IMealBuilder
{
    private Meal meal = new Meal();

    public void BuildMainCourse()
    {
        meal.AddItem("Cheeseburger");
    }

    public void BuildSide()
    {
        meal.AddItem("French Fries");
    }

    public void BuildDrink()
    {
        meal.AddItem("Soda");
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

public class MealDirector
{
    public void Construct(IMealBuilder builder)
    {
        builder.BuildMainCourse();
        builder.BuildSide();
        builder.BuildDrink();
    }
}

public class Program
{
    public static void Main()
    {
        MealDirector mealDirector = new MealDirector();

        IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
        mealDirector.Construct(healthyMealBuilder);
        Meal healthyMeal = healthyMealBuilder.GetMeal();
        healthyMeal.Display();

        Console.WriteLine();

        IMealBuilder fastFoodMealBuilder = new FastFoodMealBuilder();
        mealDirector.Construct(fastFoodMealBuilder);
        Meal fastFoodMeal = fastFoodMealBuilder.GetMeal();
        fastFoodMeal.Display();
    }
}