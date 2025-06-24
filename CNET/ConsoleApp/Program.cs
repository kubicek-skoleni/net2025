

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// 1. Najdi všechna čísla menší než 5
// 2. Najdi všechna sudá čísla
// 3. Seřaď čísla vzestupně
// 4. Najdi slova kratší než 4 znaky
// 5. Vezmi prvních 5 čísel
// 6. Přeskoč první 3 čísla a vezmi zbytek


// 7. součet znaků ve slovech začínajících na "f"
var t7 = words
    .Where(w => w.StartsWith("f"))
    .Select(w => w.Length)
    .Sum();

// 8. Existuje slovo delší než 6 znaků
var t8 = words
    .Any(x => x.Length > 6);

Console.WriteLine($"Existuje slovo delší než 6 znaků: {t8}");

// vraťte kolekci tuplů - kombinace slov jako uppercase a lowercase
// 9. vratte koleklci tuple - kombinace slov jako upper a lowercase
var taskNine = words
    .Select(w => (Upper: w.ToUpper(), Lower: w.ToLower()) );

foreach (var tuple in taskNine)
{
    Console.WriteLine($"{tuple.Upper} : {tuple.Lower}");
}