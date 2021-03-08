# ideas
description of ideas and possible implementations

## technical 

- Platform: mobile
- target OSes: Android and IOS
- engine: unity
- game characteristic: 2D pixelar

## concept
- RPG - simulator (poor to rich concept)
    - citizent
    - village manager
    - town manager
    - kindom manager </br>
    or
    - bandit
> Hard, but big variaty of mechanics. Big work is needed to create models and animations.

- Adventure
    - world with monsters and levels
> Hard, many routine level design

- Car races
    - cars and cars
    - one screen local or even online 
> Middle, easy to expand after completing the main game logic

- Monster survival
    - waves of monsters on night or day
    - equipment update
> Hard

- chess
    - for 3
    - with special rules
    - mixes with another games, e.g. pocker-chess
> Easy To Middle, many logic, but almost static models and animations

- logical-dynamic games
    - puzzle kinds
    - filling of tiles when moving, special tiles an so on
> Easy To Hard, many logic, animations and models

- monopoly
    - multiplayer games for friends
> Hard, because of design and network code


### RPG - simulator in details
- 2D world from above, camera angle about 70 degree 
- pixel models with one model for static objects and 3 models for dynamic game objects
- controls: 
    - left: moving circle
    - right: combat menu, only melee attack or alternativ comunication actions/model click/when coming closer to
    - top left/right button to open personal menu
    - time at top middle
- world rules and mechanics:
    - time
        - seasonig
            - models
            - challanges/ bonuses
            - planting restictions
    - own new buildings/farms
        - special regions for diffrent building types
    - animals variaty
        - act as small buildings in the farm
    - personal development tree with diffrent aims
        - farmer tree: cow gives more milk
    - progress bars for events
    - NPCs in the village/town etc.
        - pedestrians
        - merchendisers -> trading
    - market influence from your decisions and world events
        - prices
        - amount of goods
        - quality of goods
    - relations with regions (people can be mad at you)
        - affect prices
        - affect friendships
        - affect anger level
- goals, beginning and end points and achivement
    - can I win? is there an end?
        - yes, you can win and there is an end of the game
        - diffrent ends for diffrent life paths
    - your beginning goals?
        - give an starting village to practice (buy house,...)
            - after a point move to next ruling position after a quest chain
        - young boy, parents teach you, fight your brother and so on
            - then your parents die from plague/fire/war/sex/fall/alcoholism
            - government kills your father, you want a revenge
                - living by your grandma, killing rats in the basement
    - focus?
        - managment
        - your own game character
        - you need to do task on your own first then you can hire a person make it automated. People need to be maintained and been provided with housing
        - created items can be done by bots, but quality can be slightly worse

- Challenges
    - moddeling
    - animations 
    - system for quests -> look up the best practices
    - world architecture needs to be done before implementing
    - divide created architecture into modules (basic and features)

# Stages

## I Core functional

### phase 1
- Movement left, right, top, bottom
- House. Enter buildings
- Tiles

### phase 2
- 1 NPC model including the interaction
- Interface menu with tabs

### phase 3
- items

### phase 4 
- Saves
- Craft System

## Experience model

ref: https://onlyagame.typepad.com/only_a_game/2006/08/mathematics_of_.html

ref: https://www.davideaversa.it/blog/gamedesign-math-rpg-level-based-progression/

- core level
    - gives ability points
- side levels
    - consume ability points to imrove one skill in a life path
    - life paths 
        - survival
        - education
        - production


## II Farmer

### time
- day night change
- season change

### planting routine
- plants
    - core crops
    - additional crops for working on the plants
        - cleaning up
        - watering
- place for planting
- planting by yourself
    - autoplanting logic
    - 

## III Quests 
- single quest object
    - target of the quest
    - links to previous/next quests
    - category
    - description
    - hints
- quest overview
    - categorization into life paths/ common quests
    - details of each quest
    - select/track/hide quests

## IV Trader

- truck
- market
