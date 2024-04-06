import requests
from time import sleep

url = 'https://localhost:44356/api/Content?Page=1&PageSize=100'
headers = {
    'accept': '*/*'
}

for i in range(1000):
    response = requests.get(url, headers=headers, verify=False)
    print(f'Anfrage {i+1}: Status Code {response.status_code}')
    sleep(0.5)