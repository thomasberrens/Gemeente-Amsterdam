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
  // uitleg over feature
  
  De code die bij deze feature vind kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/master/Assets/Scripts/ScoreSystem) vinden.
  
  ![Score Feature Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Score_Feature_Sheet.png?raw=true)
  
  ### Cut Scene Visual Sheet
  // uitleg over feature
  
  De code die bij deze feature vind kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/master/Assets/Scripts/CutScene) vinden.
  
  ![Cut Scene Behaviour](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Cut_Scene_Behaviour_Sheet.png?raw=true)
  
  ### Transition Manager Visual Sheet
  
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
 
 De code die bij deze feature vind kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/develop/Assets/Scripts/Audio/AudioManager.cs) vinden.
 
  ![User Interface Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Audio_Manager_Sheet.png?raw=true)

---

## Thomas Berrens:

 ### Interactable Scenario Visual Sheet
 Hier laat ik zien hoe je een (interactable) scenario kan configureren.
 
 De code van de intertactable scneario manager kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/develop/Assets/Scripts/ScenarioBuilder/InteractableScenarioManager.cs) vinden.
 
 De manager heeft ook ondersteunende scripts, die kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/develop/Assets/Scripts/ScenarioBuilder) vinden.
 
 De scenarios kan je [hier](https://github.com/thomasberrens/Gemeente-Amsterdam/tree/develop/Assets/InteractableScenarios) vinden.
 
  ![User Interface Visual Sheet](https://github.com/thomasberrens/Gemeente-Amsterdam/blob/master/Wiki/VS_Interactable_Scenario.png?raw=true)
