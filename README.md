# HackathonSnorkelSG

Click on the screenshot to see a walkthrough in German.

[![SC2 Video](https://raw.githubusercontent.com/DavidEggenberger/HackathonSnorkelSG/master/WebAPI/SnorkleSG.PNG)](https://www.youtube.com/watch?v=qLxkJVdA-Mw&t=1s&ab_channel=DavidSeesSharp "Click to Watch a walkthrough (in German)")

The goal of Snorkle is to give users a platform where they can explore local attractions. The attractions are shown on a 3d map (MapBox). If the users are logged in (Google, LinkedIn, GitHub) they can also create attractions themselfs. Through drag/drop they add information (history, activities, general description, image) about it. Azure Cognitive Services (Computer Vision) automatically detect objects in the image. All the provided information together with the image of the attraction result in a snorkel. It helps tourists to dive into the attraction. They see the snorkel when they click on the attraction on the map. The image and the stored information is shown. Through an iframe also a Google StreetView and the directions from the users location to the attraction using public transport is displayed. When a user visits an attraction he/she can check-in. All the loggedin users see a realtime overview over the checked-in visitors of an attraction. 


