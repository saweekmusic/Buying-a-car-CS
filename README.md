# Buying a car

### What we must do?
Let us begin with an example:

A man has a rather old car being worth $2000. He saw a secondhand car being worth $8000. He wants to keep his old car until he can buy the secondhand one.

He thinks he can save $1000 each month but the prices of his old car and of the new one decrease of 1.5 percent per month. Furthermore this percent of loss increases of 0.5 percent at the end of every two months. Our man finds it difficult to make all these calculations.

**Can you help him?**

How many months will it take him to save up enough money to buy the car he wants, and how much money will he have left over?

**Parameters and return of function:**

```
parameter (positive int or float, guaranteed) startPriceOld (Old car price)
parameter (positive int or float, guaranteed) startPriceNew (New car price)
parameter (positive int or float, guaranteed) savingperMonth 
parameter (positive float or int, guaranteed) percentLossByMont

nbMonths(2000, 8000, 1000, 1.5) should return [6, 766] or (6, 766)
```

**Detail of the above example:**
```
end month 1: percentLoss 1.5 available -4910.0
end month 2: percentLoss 2.0 available -3791.7999...
end month 3: percentLoss 2.0 available -2675.964
end month 4: percentLoss 2.5 available -1534.06489...
end month 5: percentLoss 2.5 available -395.71327...
end month 6: percentLoss 3.0 available 766.158120825...
return [6, 766] or (6, 766)
```
where 6 is the number of months at the end of which he can buy the new car and 766 is the nearest integer to 766.158... (rounding 766.158 gives 766).

**Note:**

Selling, buying and saving are normally done at end of month. Calculations are processed at the end of each considered month but if, by chance from the start, the value of the old car is bigger than the value of the new one or equal there is no saving to be made, no need to wait so he can at the beginning of the month buy the new car:
```
nbMonths(12000, 8000, 1000, 1.5) should return [0, 4000]
nbMonths(8000, 8000, 1000, 1.5) should return [0, 0]
```
We don't take care of a deposit of savings in a bank:-)

### What we did?
1. Мы создали переменную diff с отрицательным значением для того что бы в будущем мы смогли сделать цикл.
2. мы сделали проверку, что если цена старого авто больше или равна цене нового авто, то тогда смысла копить и ждать нет. Так что мы возвращаем количество месяцев - 0, и разницу между ценой старой и новой машины.
3. В противном случае у нас будет выполняться основные подсчёты.
4. Создаём переменную month сразу, ибо если мы создадим в цыкле то мы не сможем вернуть его значение.
5. Создаём переменную saving и приравнимаем к значению savingPerMonth, для того что бы сохранить исходное число, которое в будущем мы будем использоывать.
6. Создаём цикл FOR, который роботает пока разница между машинами ниже 0, и с каждым кругом добовляем 1 к month.
7. Делаем проверку. Если при делении month на 2 остаток будет не 0, тогда делаем следующий код. Почему именно так?
А задаче сказано что подсчёт производится в конце месяца. Сначала подсчёт потом + 1 к month. Если у нас изначально month будет 1 то в конце нам надо будет отнимать одно число, а это + 1 строка кода. Вторая причина. Если у нас будет month % 2 == 0, тогда у нас не верно условие задачи, ибо тогда будет новый процент каждый первый месяц.
8. Если условие верно - мы изменяем наш процент, а именно добавляем к нем 0,5.
9. Изменяем старую центу относительно текущего процента. От числа отнимаем процент от числа. 
10. Аналогично с новой машиной.
11. Узнаём разницу отниманием суммы новой цены от старой и добавляем число которое мы каждый месяц откладываем.
12. Так как это окончание месяца мы добавляем к имеющимся отложениям еще.
13. В противном, если при делении month на 2 остаток будет 0 то делаем пункты с 9 по 12.
14. Возвращаем значения month и разницу между машинами
```cs
return new int[] {month, (int)Math.Round(diff)};
```

#FUNDAMENTALS #MATHEMATICS #ALGORITHMS #NUMBERS

[Buying a car CodeWars](https://www.codewars.com/kata/554a44516729e4d80b000012/train/csharp)