# Gemeente-Amsterdam
In deze repository vind je veel informatie over ons examenopdracht voor gemeente Amsterdam. Ook vind je hier een aantal gevisualiseerde geproduceerde game onderdelen. 
Onze planning en wiki zijn te vinden hieronder bij belangrijke links.

## Belangrijke links:
Er is ook veel informatie te vinden in onze [wiki](https://github.com/thomasberrens/Gemeente-Amsterdam/wiki).
Onze planning is te vinden op onze [Trello](https://trello.com/b/I5btxegt/gemeente-amsterdam).

We hebben ook nog 2 andere Github gebruikt voor onze website die gekoppeld is aan de game.
- Hier hebben we een Github link voor de website: [Gemeente Amsterdam Website](https://github.com/thomasberrens/Gemeente-Amsterdam-Website).
- Ook hebben we een seperate API github gemaakt voor de communicatie van web naar onze game: [Gemeente Amsterdam API](https://github.com/thomasberrens/Gemeente-Amsterdam-API).

We hebben besloten om deze compleet los in een andere repositories gemaakt omdat andere codetalen en andere git conventies zijn dan het Unity project zelf. Deze andere gitconventies kan je teruglezen in de [Github Conventions](https://github.com/thomasberrens/Gemeente-Amsterdam/wiki/Github-Flow) op de wiki. 

# De opdracht:
In het algemeen zal het spel een simulatie zijn van een dag werken bij de gemeente Amsterdam, waarbij de speler interacties en keuzes moet maken die hun score beïnvloeden. Het spel begint met een startscherm waar de speler het spel kan starten. Je wilt als speler naar je kantoor om je dag te beginnen en te werken totdat je klaar bent met de werkdag. voordat je bij je kantoor bent krijg je al interacties wat bestaat uit valse e-mails, social engineering, valse telefoontjes, oplichters, etc, de interacties krijg je inderdaad ook tijdens de werkdag achter je kantoor.
Een complete en uitgebreide beschrijving is in het functioneel ontwerp (onderdeel van de [wiki](https://github.com/thomasberrens/Gemeente-Amsterdam/wiki/Functioneel-Ontwerp)).

---

# Geproduceerde Game Onderdelen

## Visual sheets:
Hier laten wij wat van ons werk wat visueler zien dan code. Dit helpt om duidelijk onze code uit te leggen naar opdrachtgevers, beoordelaars en derde partijen.
Door middel van tekst en kleuren leggen we uit wat voor systemen we hebben gemaakt.

---

## Dean Hendriks:

  ### Score Visual Sheet
  
  Hier laat ik de flow van hoe de score system werkt aan de hand van kleuren en een korte uitleg van de code in de feature sheet.
  
  De code die bij deze feature hoort kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/master/Assets/Scripts/ScoreSystem) vinden.
  
  ![Score Feature Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Score_Feature_Sheet.png?raw=true)
  
  ### Cut Scene Visual Sheet
  
  Hier laat ik de flow van de Cut Scene behaviour zien aan de hand van kleuren en een korte uitleg van de code in de feature sheet.
  
  De code die bij deze feature hoort kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/master/Assets/Scripts/CutScene) vinden.
  
  ![Cut Scene Feature Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Cut_Scene_Behaviour_Sheet.png?raw=true)
  
  ### Transition Manager Visual Sheet
  
  hier laat ik de flow van de Transition Manager zien aan de hand van kleuren en een korte uitleg van de code in de feature sheet.
  
  De code die bij deze feature hoort kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/develop/Assets/Scripts/Transition) vinden.
  
  ![Transition Feature Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Transition_ManagerFeature_Sheet.png)
  
  ---
  
## Jason Dikken:

 ### User Interface Visual Sheet
 
 Hier laat ik de flow van het menu scherm zien met verschillende kleuren zodat je duidelijk kan zien wat elke knop precies doet.
 
 De code van de scene switcher kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Assets/Scripts/SceneSwitcher.cs) vinden.
 
 De User Interface art kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/master/Assets/Art/UI) terugvinden.
 
  ![User Interface Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_User_Interface_Flow.png?raw=true)

  ### Audio Manager Visual Sheet
 
 Dit legt uit hoe mijn audio script werkt met de unity audio listener en audio sources. In mijn script zoek ik de audio source op en dan zet ik de audio clip erin.
 Deze functies roep ik aan via een Unity event op een button.
 
 De code die bij deze feature hoort kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/develop/Assets/Scripts/Audio/AudioManager.cs) vinden.
 
  ![User Interface Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Audio_Manager_Sheet.png?raw=true)

---

## Thomas Berrens:

 ### Interactable Scenario Visual Sheet
 Hier laat ik zien hoe je een (interactable) scenario kan configureren.
 
 De code van de intertactable scenario manager kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/develop/Assets/Scripts/ScenarioBuilder/InteractableScenarioManager.cs) vinden.
 
 De manager heeft ook ondersteunende scripts, die kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/develop/Assets/Scripts/ScenarioBuilder) vinden.
 
 De scenarios kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/develop/Assets/InteractableScenarios) vinden.
 
  ![User Interface Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Interactable_Scenario.png?raw=true)
  
  ### Player Analytics
 Hier laat ik zien hoe de keuze word weergegeven op de website.
 [code](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/develop/Assets/Scripts/ScenarioBuilder/InteractableScenarioManager.cs) om de data van de game naar de server toe te sturen kan je onder de functie "SendChoice()" vinden.

De code om zo een grafiek weer te geven kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam-Website/blob/master/src/components/ChoiceGraph.vue) vinden.
 ![Choice Analytics Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Choice_Analytics.png?raw=true)
 
### Search filter
Hier kunt u zien hoe de zoekbalk op de website werkt, zodat u door spelers heen kan filteren.
De code ervan kunt u [hier](https://github.com/thomasberrens/Gemeente-Amsterdam-Website/blob/master/src/views/DashboardView.vue) vinden onder de functie "filterPlayers"
 ![Dashboard Search Filter Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Dashboard_Search_Filter.png?raw=true)
 
 ### Score Calculation
Hier kunt u zien hoe de hoogste haalbare score word uitgerekend en vervolgens word omgezet naar een score van 0 tot 10, de volledige code kunt u ook [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Assets/Scripts/ScoreSystem/ScoreManager.cs) vinden.
![Score Calculation Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Score_Calculation.png?raw=true)
