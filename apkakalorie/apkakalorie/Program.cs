using apkakalorie.Database;
using apkakalorie.Models;
using apkakalorie.Service;

ServiceMenu listOptionMenu = new ServiceMenu();

listOptionMenu.AddMenuToList(1, "Sekcja przepisow");
listOptionMenu.AddMenuToList(2, "Sekcja produktow");

ServiceMenu listRecipeMenu = new ServiceMenu();

listRecipeMenu.AddMenuToList(1, "Zobacz Przepis");
listRecipeMenu.AddMenuToList(2, "Utworz nowy przepis");
listRecipeMenu.AddMenuToList(3, "Zaktualizuj przepis");
listRecipeMenu.AddMenuToList(4, "Usun przepis");
listRecipeMenu.AddMenuToList(5, "Powrot");

ServiceMenu listProductMenu = new ServiceMenu();

listProductMenu.AddMenuToList(1, "Zobacz Produkt");
listProductMenu.AddMenuToList(2, "Utworz nowy produkt");
listProductMenu.AddMenuToList(3, "Zaktualizuj produkt");
listProductMenu.AddMenuToList(4, "Usun produkt");
listProductMenu.AddMenuToList(5, "Powrot");

ServiceProduct productService = new ServiceProduct();
ServiceRecipe recipeService = new ServiceRecipe();

int number = 0;

while (true)
{
    int numerMenu = listOptionMenu.ShowMenu();

    switch (numerMenu)
    {
        case 1: ShowSubMenu(listRecipeMenu, recipeService: recipeService); break;
        case 2: ShowSubMenu(listProductMenu, productService: productService); break;
        default:Console.WriteLine("Brak dostepnego Menu"); break;
    };
}

 void ShowSubMenu(ServiceMenu menu, ServiceRecipe recipeService = null, ServiceProduct productService = null)
{
    int inputNumber = menu.ShowMenu();

    if (recipeService != null)
    {
        switch (inputNumber)
        {
            case 1:
                recipeService.GetAllRecipe(); break;
            case 2: Console.WriteLine("dodaj"); break;
            case 3: Console.WriteLine("update"); break;
            case 4: Console.WriteLine("usun"); break;
            case 5: Console.WriteLine("powrot"); break;
            default:
                Console.WriteLine("Brak dostepnego Menu"); break;
        }

    }
    else 
    {
        switch (inputNumber)
        {

        case 1:
           productService.GetAllProduct(); break;
        case 2: AddProduct(productService); break;
        case 3: Console.WriteLine("update"); break;
        case 4: Console.WriteLine("usun"); break;
        case 5: Console.WriteLine("powrot"); break;
        default:
            Console.WriteLine("Brak dostepnego Menu"); break;

        }
    }
}

void AddProduct(ServiceProduct productService)
{
    Product p = new Product();

    Console.WriteLine("Podaj nazwę produktu:");
    p.Name = Console.ReadLine();

    Console.WriteLine("Podaj kalorie na 100g:");
    p.CaloriesPer100g = ReadDoubleFromUser();

    Console.WriteLine("Podaj białko na 100g:");
    p.ProteinPer100g = ReadDoubleFromUser();

    Console.WriteLine("Podaj tłuszcz na 100g:");
    p.FatPer100g = ReadDoubleFromUser();

    Console.WriteLine("Podaj węglowodany na 100g:");
    p.CarbsPer100g = ReadDoubleFromUser();

    productService.AddNewProduct(p);
}

double ReadDoubleFromUser()
{
    while (true)
    {
        string input = Console.ReadLine();
        if (Double.TryParse(input, out double value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("Niepoprawna liczba. Spróbuj ponownie:");
        }
    }
}