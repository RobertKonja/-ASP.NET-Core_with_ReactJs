# InterviewTask
TRANSLATER/ASP.NET_CORE_whit_REACT
##Translater for enlglish words (include Chinise words and special characters)
## Practicing operations with fetch request in ReactJs and ASP.NET Core Web API  endpoints.
## Solving  task : we are given an excel spreadsheet whit word in english  and anoder 4 diferent language, we need to make a database from the data, the data contains special characters and Chinese words.

##  Problem solved:-first create database whit Microsoft SQL server management studio,
                    - use Entity framework Databse first approach and create model .
                    - because use special character for feching (front-end side /reactjs ) i used  encodeURIComponent(wt);
                    - also need in server side in controller action use the System.Net.WebUtility.UrlDecode(word);
##-Open InterviewTask folder in(it is located in master)
- Visual Studio 2019
-The project uses a local SQL database.\


Use this  as a server, when the application is launched\
copy the url address into the Visual studio code  ( expl.=>  Http://localhost:54820)\
Leave the running application in the background \                                             
                                                                                              
##-Open   clientReact (it is located in branch)  folder in                                                           
-Visual Studio Code                                                                          
Open 'src'  folder    => then open ' Components ' folder  =>  in   ' NewSearch.jsx'  Change      
                                                                                              
function reloadPage() {
            
        var  url = "https://localhost:44316/api/Dictionary/word/" + eng;                                                                                    
                          "localhost:54820" ,                          <=====change this   whit your server localhost================<<<                                              
     }\
     
 Run  Visual code ,terminal typing  :- npm install    
                           then     -  npm start   
