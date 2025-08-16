using apkakalorie.Database;
using apkakalorie.Models;
using apkakalorie.Service;
using apkakalorie.ConsoleUI;

Context context = new Context();

ServiceMenu listOptionMenu = new ServiceMenu();
ServiceMenu listRecipeMenu = new ServiceMenu();
ServiceMenu listProductMenu = new ServiceMenu();
ServiceMenu listMenuProductInRecipe = new ServiceMenu();

AddAllMenu(listOptionMenu, listRecipeMenu, listProductMenu);

ServiceProduct productService = new ServiceProduct(context);
ServiceRecipe recipeService = new ServiceRecipe(context);

int number = 0;

while (true)
{
    int numerMenu = listOptionMenu.ShowMenu();

    switch (numerMenu)
    {
        case 1: ShowSubMenu(listRecipeMenu, recipeService: recipeService, productService: productService); break;
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
            case 1: RecipeConsoleUI.GetAllRecipe(recipeService); break;
            case 2: RecipeConsoleUI.CreateRecipe(recipeService, productService); break;
            case 3: RecipeConsoleUI.UpdateRecipeFromUser(recipeService, listMenuProductInRecipe, productService); break; 
            case 4: RecipeConsoleUI.DeleteRecipeWithIdFromUser(recipeService); break;
            case 5: ShowSubMenu(listOptionMenu); break;
            case 6: Console.WriteLine("szukaj przepisu konkretnego po id"); break;
            default:
                Console.WriteLine("Brak dostepnego Menu"); break;
        }
    }
    else 
    {
        switch (inputNumber)
        {

        case 1: ProductConsoleUI.ShowAllProducts(productService); break;
        case 2: ProductConsoleUI.CreateProductFromUserInput(productService);  break;
        case 3: ProductConsoleUI.UpdateProductFromUserInput(productService);  break;
        case 4: ProductConsoleUI.DeleteProductById(productService);   break;
        case 5: ShowSubMenu(listOptionMenu); break;
        default:
            Console.WriteLine("Brak dostepnego Menu"); break;

        }
    }
}


 void AddAllMenu(ServiceMenu listOptionMenu, ServiceMenu listRecipeMenu,ServiceMenu listProductMenu) 
{
    listOptionMenu.AddMenuToList(1, "Sekcja przepisow");
    listOptionMenu.AddMenuToList(2, "Sekcja produktow");

    listRecipeMenu.AddMenuToList(1, "Zobacz Przepis");
    listRecipeMenu.AddMenuToList(2, "Utworz nowy przepis");
    listRecipeMenu.AddMenuToList(3, "Zaktualizuj przepis");
    listRecipeMenu.AddMenuToList(4, "Usun przepis");
    listRecipeMenu.AddMenuToList(5, "Powrot");

    listProductMenu.AddMenuToList(1, "Zobacz Produkt");
    listProductMenu.AddMenuToList(2, "Utworz nowy produkt");
    listProductMenu.AddMenuToList(3, "Zaktualizuj produkt");
    listProductMenu.AddMenuToList(4, "Usun produkt");
    listProductMenu.AddMenuToList(5, "Powrot");


    listMenuProductInRecipe.AddMenuToList(1, "Zmiana przepisu");
    listMenuProductInRecipe.AddMenuToList(2, "Dodanie produktow");
    listMenuProductInRecipe.AddMenuToList(3, "Usuniecie produktow");
    listMenuProductInRecipe.AddMenuToList(4, "Aktualizacja produktu?????");
}