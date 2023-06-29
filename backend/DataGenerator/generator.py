from faker import Faker
from random import randint, shuffle, choice, uniform
from string import ascii_letters

from constants import *


def generate_customers():
    """
        Генерация таблицы
        покупателей.
    """

    faker = Faker()

    file = open(CUSTOMERS_FILE, 'w')

    for i in range(RECORDS_NUMBER):
        name = faker.first_name()
        surname = faker.last_name()
        phone = faker.unique.numerify('%%%%%%%%%%%')

        record = '{0}|{1}|{2}|{3}\n'.format(i + 1, name, 
                                            surname, phone)
        file.write(record)
    
    file.close()


def generate_sales(wines):
    """
        Генерация таблицы
        продаж.
    """

    faker = Faker()

    file = open(SALES_FILE, 'w')

    customers_id = list(range(1, RECORDS_NUMBER + 1))

    for i in range(RECORDS_NUMBER):
        customer_id = choice(customers_id)

        wine = choice(wines)

        supplier_wine_id = wine['id']
        purchase_price = wine['price']
        selling_price = purchase_price * (1 + wine['percent'] / 100.0)
        wine_number = randint(MIN_WINE_NUMBER, MAX_WINE_NUMBER)
        profit = (selling_price - purchase_price) * wine_number

        date = faker.date().split('-')
        date = str(date[2] + '.' + date[1] + '.' + date[0])

        record = '{0}|{1}|{2}|{3:.5}|{4:.4}|{5:.5}|{6}|{7}\n'.format(
            i + 1, customer_id, supplier_wine_id, selling_price,
            purchase_price, profit, date, wine_number)

        file.write(record)

    file.close()


def generate_wines():
    """
        Генерация таблицы
        вин.
    """

    file = open(WINES_FILE, 'w')
    wines = {}

    for i in range(RECORDS_NUMBER):
        color = choice(COLORS)
        sugar = choice(SUGAR)
        volume = choice(VOLUMES)
        alcohol = uniform(MIN_ALCOHOL, MAX_ALCOHOL)
        number = randint(MIN_NUMBER, MAX_NUMBER)
        wines[i + 1] = number

        if color == 'red':
            kind = choice(RED_KINDS)
        elif color == 'white':
            kind = choice(WHITE_KINDS)
        elif color == 'rose':
            kind = choice(ROSE_KINDS)

        record = '{0}|{1}|{2}|{3}|{4}|{5:.3}|{6}\n'.format(
                  i + 1, kind, color, sugar, 
                  volume, alcohol, number)
        file.write(record)

    file.close()
    return wines


def generate_suppliers():
    """
       Генерация таблицы
       поставщиков.
    """

    faker = Faker()

    file = open(SUPPLIERS_FILE, 'w')

    for i in range(RECORDS_NUMBER):
        name = faker.unique.company()
        country = choice(COUNTRIES)
        license = choice([True, False])

        record = '{0}|{1}|{2}|{3}\n'.format(i + 1, name, 
                                            country, license)
        file.write(record)
    
    file.close()


def generate_supplier_wines(wines):
    """
        Генерация таблицы
        вин поставщиков.
    """

    file = open(SUPPLIER_WINES_FILE, 'w')

    supplier_wines = []
    supplier_wine_id = 0

    for i in range(RECORDS_NUMBER):
        wine_id = i + 1
        suppliers = list(range(1, RECORDS_NUMBER + 1))
        shuffle(suppliers)

        for _ in range(wines[wine_id]):
            supplier_id = choice(suppliers)
            suppliers.remove(supplier_id)
            price = uniform(MIN_PRICE, MAX_PRICE)
            percent = randint(MIN_PERCENT, MAX_PERCENT)

            supplier_wine_id += 1

            record = '{0}|{1}|{2}|{3:.4}|{4}\n'.format(supplier_wine_id, 
                      supplier_id, wine_id, price, percent)
            file.write(record)

            wine = {}
            wine['id'] = supplier_wine_id
            wine['price'] = price
            wine['percent'] = percent

            supplier_wines.append(wine)

    file.close()
    return supplier_wines


def generate_users():
    """
        Генерация таблицы 
        пользователей.
    """

    customers = [[i, 'customer'] for i in range(1, RECORDS_NUMBER + 1)]
    suppliers = [[i, 'supplier'] for i in range(1, RECORDS_NUMBER + 1)]
    users = customers + suppliers
    shuffle(users)

    faker = Faker()

    file = open(USERS_FILE, 'w')

    for i, user in enumerate(users):
        profile = faker.simple_profile()
        login = profile['username']
        password = ''.join(choice(ascii_letters) 
                for _ in range(randint(MIN_PASSWORD_LEN, MAX_PASSWORD_LEN)))

        record = '{0}|{1}|{2}|{3}|{4}\n'.format(i + 1, user[0], login,
                                                password, user[1])
        file.write(record)

    file.close()


if __name__ == "__main__":
    generate_customers()
    generate_suppliers()
    generate_users()
    wines = generate_wines()
    supplier_wines = generate_supplier_wines(wines)
    generate_sales(supplier_wines)
