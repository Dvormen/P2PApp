# P2PApp

Peer to peer app with web page ui

---

## Features

- Adding and removing accounts
- Depositing and withdrawing money
- Web page UI with bank data

---

## Getting Started
---
## Installing

1. Download the zip file from GitHub here:  
   https://github.com/Dvormen/P2PApp.git

2. Extract the zip file and open `P2P-exe` folder.

3. Run the exe file in `P2P-exe` folder.

4. In your web browser, open http://localhost:5000/ to see the UI
---

## After running the program

To operate, you need to open PuTTY and enter:
   ip - 127.0.0.1
   port - 65525
   connection - RAW
You are now connected
---

## Commands

### 1. Bank code
  command - BC
  Displays the local bank id

---

### 2. Create account
  command - AC
  Creates a new account in the local bank and displays its number

---

### 3. Account deposit
  command - AD <account_number>/<bank_id> <money>
  Deposits an amount of money into an account

---

### 4. Account withdrawal
  command - AW <account_number>/<bank_id> <money>
  Withdraws an amount of money from an account
  
---

### 5. Account balance
  command - AB <account_number>/<bank_id>
  Displays the amount of money in the account

---

### 6. Remove account
  command - AR <account_number>/<bank_id>
  Removes the account from local bank 

---

### 7. Bank finances
  command - BA
  Displays the combined funds of the local bank

---

### 8. Bank clients
  command - BN
  Displays the total amount of account in the local bank

---

## Help

If you need further help with this application, feel free to contact us at:

**dvorak13@spsejecna.cz**
or
**herich@spsejecna.cz**
