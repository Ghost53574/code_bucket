import cv 

def Convert(image):
    orig = cv.LoadImage(image)
    cv.ShowImage("orig", orig)
    hsv = cv.CreateImage(cv.GetSize(orig), 8, 3)
    hue = cv.CreateImage(cv.GetSize(orig), 8, 1)
    sat = cv.CreateImage(cv.GetSize(orig), 8, 1)
    val = cv.CreateImage(cv.GetSize(orig), 8, 1)
    cv.CvtColor(orig, hsv, cv.CV_RGB2HSV)
    cv.Split(hsv,hue,sat,val,None)
    query = cv.CreateImage(cv.GetSize(orig), 8, 1)
    result = cv.CreateImage(cv.GetSize(orig), 8, 1) 
    for i in range(0,255):
        cv.Set(query,i)
        cv.Cmp(query,hue,result,cv.CV_CMP_EQ)
        if (cv.CountNonZero(result)>1000): # <-what is signficant?
            cv.ShowImage(str(i),result)
            cv.SaveImage(str(i)+".png",result)
            cv.WaitKey(-1)

with open("list", 'r') as out:
    for line in out:
        input("next")
        Convert(line)
    
    
    
    
