# Oppgaver:

### Forutsetning:
1. Clone dette repoet.
2. Installer Docker Desktop hvis du ikke allerede har gjort det. 


### Bygg App1 og App2 imager
1. Gå inn i App1 mappen i dette repoet via terminalen
2. Skriv `docker build .` Dette bygger imaget for App1. Hvis du vil navngi imaget kan du legge på `-t mittimage` på slutten. Punktumet sier at contexten er i denne mappen. Da vil den automatisk finne Dockerfile selv. Skulle man vært mer eksplisitt kunne man ha skrevet
`docker build . -f Dockerfile -t mittimage`.
Vi kan også stå i root mappen i repo'et, men da må vi endre context'n til å være App1. 
`docker build App1`. Når Dockerfile er i samme mappe som context'n, trenger vi ikke å spesifisere Dockerfile med `-f`
3. Gratulerer du har bygget imaget
4. Hvis du skriver `docker image ls` vil imaget normalt vises i toppen av listen. Hvis du ikke ga det et navn vil den opprette et unik navn for deg.
5. Hvis du vil kan du inspisere imaget. Dette kan du gjøre dette enten ved å skrive `docker image inspect imagetnavnetduga` eller så
kan du finne imaget i Docker Desktop GUI og inspisere derfra.
6. Er du skikkelig ivrig kan prøve å push imaget til et privat container registry. F.eks Docker Hub. 
7. Prøv gjerne å bygge image av App2 også. Så får du det inn i fingrene. Du ødelegger ikke noe :sweat_smile:

Disse applikasjonene bruker Seq og RabbitMq. Så enten kan du installere disse manuelt, eller bruke docker. Da velger du selvsagt alternativ nr to :D
Selvom det kun er to eksterne verktøy er det kjedelig å kjøre en og en opp med docker.
Hadde det ikke vært deilig å starte alt med noen få tastetrykk?

### Start docker compose

1. Stå i root folderen av dette repositoriet i terminalen og kjør `docker compose build`. Dette bygger imagene til App1 og App2.
2. Skriv `docker compose up`. Dette starter opp alle containerne. Legg på `-d` på slutten for å starte de detached.
3. Nå vil Seq, RabbitMq, App1 og App2 starte opp. Du vil nok få noen feilmelding i loggen i starten. 
Dette er fordi App1 og 2 prøver å koble seg mot RabbitMq og Seq før de oppe og kjører. Det er helt normalt.
4. Nå er Seg tilgjenglig på `http://localhost:5341`
5. RabbitMq på `http://localhost:15672`
6. `docker-compose.yaml` som inneholder oppskriften kan du finne i root mappen.
7. Når du er lei eller vil frigjøre ressurser kan du stoppe containerne ved å skrive `docker compose stop` 
Merk. Dette fjerner ikke containerne. Kun stopper de. Du kan starte de opp igjen ved å skrive `docker compose start`.
Ingen data er fjernet fra containerne. 
Ønsker du å resette hele miljøet og fjerne alle containere kan du skrive `docker compose down`.
For å starte opp igjen da, må du kjøre `docker compose up`.
8. For å få en oversikt over status på containerne kan du skrive `docker compose ps`
9. Hvis du f.eks har lyst til å debugge App1 i Visual Studio/Rider, stopper du denne ved å skrive `docker compose stop app1`.
Deretter starter du App1 i VS/Rider.
10. Gjør du kodeendringer og ønsker å få opp containere med den nye koden må du bygge imagene på nytt. `docker compose build`
11. Ønsker du å starte en stoppet container, skriver du `docker compose start app1`
12. Se gjerne `docker compose help` for yttligere muligheter.


