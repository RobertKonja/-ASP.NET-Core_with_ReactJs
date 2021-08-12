import React, { useState}from "react";
import Laguage from "./language.js";

function NewSearch() {
    
    
    const [eng, setEng] = useState("");
    const [transData, setTransData] = useState({});
    const [error, setError] = useState(null);
   
    function handleChange(e) {
        var w= (e.target.value);
        if (w !== null  || w !=="") {
            console.log("before trim ",w);
            var wt = w.trim();
           console.log("after trim", wt);
       // must youse encode because input word content '/' and spec. caracters   
             var we = encodeURIComponent(wt);
           setEng(we);
            
        }
        console.log("handlechange", eng);
            
    }
                
    
    function reloadPage() {
     
        
        var  url = "https://localhost:44316/api/Dictionary/word/" + eng;
        fetch(url)
            .then(res => {
                if (!res.ok) {
                    throw Error("*********WORD IS NOT FOUND *****");
                } return res.json();
            })
            .then((result) => { setTransData(result);setError(null) })
            
            .catch(err => {
               
                setError(err.message);
                setTransData({});
            });
    }
    
    
    console.log(transData);
    
      
    return (
    <div >
              
             <div className="card"> 
                <div className="" > Input word  in English     </div>
                <input  className="card" onChange={handleChange} placeholder=" type english word "  type="text" />
                    
                <button onClick={reloadPage} className="btn" >  Translate     </button>
                    
               {error &&<div  >  <span  className="errorfont" >{error} </span></div>}
            
            </div>
               <span> 
                <Laguage lang="hungary"  object={transData.hungarian} />
                <Laguage lang="portugal " object={transData.portuguese} />
                <Laguage lang="chinese" object={transData.chinese} />
                <Laguage lang="spain" object={transData.spanish} />
              </span>
    </div>
    
          
           

    )
} export default NewSearch;