*** Settings ***
Library    RPA.Windows

*** Test Cases ***
Bejelentkezés adminisztrátorként
    Launch App    
    Click    name:"Jelszó:"
    Send Keys    keys=admin

    Send Keys    keys={Tab}   
    Send Keys    keys=admin

    Click    name:"Bejelentkezés"
    Sleep   1s
    Click    name:"Bezárás"

Bejelentkezés helytelen jelszóval
    Launch App    
    Click    name:"Jelszó:"
    Send Keys    keys=admin

    Send Keys    keys={Tab}   
    Send Keys    keys=wrongpassword

    Click    name:"Bejelentkezés"

    Sleep    3s
    
    Click    name:"OK"
    Sleep    1s
    Click    name:"Bezárás"

Esemény hozzáadása
    Launch App    
    Click    name:"Jelszó:"
    Send Keys    keys=admin

    Send Keys    keys={Tab}   
    Send Keys    keys=admin

    Click    name:"Bejelentkezés"
    Click    name:"Esemény hozzáadása"
    Send Keys    keys={Tab}
    Send Keys    keys=Test Event
    Send Keys    keys={Tab}
    Send Keys    keys=Test Event Description
    Send Keys    keys={Tab}
    Send Keys    keys={Right}
    Send Keys    keys={Tab}
    Send Keys    keys={Right}
    Click    name:"Hozzáadás"
    

Esemény módosítása
    Launch App    
    Click    name:"Jelszó:"
    Send Keys    keys=admin

    Send Keys    keys={Tab}   
    Send Keys    keys=admin

    Click    name:"Bejelentkezés"

    Click    name:"Események nézése"
    Click    name:"Esemény Sor: 0"
    Click    name:"Megnyitás"
    Send Keys    keys={Down}
    Send Keys    keys={Down}
    Send Keys    keys={Down}
    Send Keys    keys={Enter}
    Click    name:"Mentés"

Regisztráció Teszt
    Launch App    

    Click    name:"Regisztráció"
    Click    name:"Jelszó:" and type:Edit
    Send Keys    keys=RegTest2

    Send Keys    keys={Tab}   
    Send Keys    keys=RegTest2

    Click    name:"Regisztráció"
    Click    name:"Bezárás"
    
Kijelentkezés Admin fiókból
    Launch App    
    Click    name:"Jelszó:"
    Send Keys    keys=admin

    Send Keys    keys={Tab}   
    Send Keys    keys=admin

    Click    name:"Bejelentkezés"

    Sleep    1s

    Click    name:"admin"
    Click    name:"Kijelentkezés"
    Sleep    1s
    Click    name:"Bezárás"



*** Keywords ***


Launch App
    Windows Run    "C:\\Users\\Kocsi\\Desktop\\Esemeny-Kezelo-main\\Esemény Kezelő\\bin\\Debug\\Esemény kezelő.exe"
    
    Sleep    1s
    
    Control Window    executable:"Esemény kezelő.exe"

    
