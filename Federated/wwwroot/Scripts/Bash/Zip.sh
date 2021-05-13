#!/bin/bash

cd /app/wwwroot/Scripts/Python/MSDA_Querry3
/usr/bin/zip -r result_$(date +'%F_%R').zip results

sleep 6
 
touch DoneZ.txt




mv /app/wwwroot/Scripts/Python/MSDA_Querry3/*.zip /app/wwwroot/Scripts/Python/MSDA_Querry3/Data/


echo "Zip file is ready to send"





