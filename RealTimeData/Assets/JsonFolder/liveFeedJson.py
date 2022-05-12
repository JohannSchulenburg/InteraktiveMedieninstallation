import numpy as np
import cv2
import copy
import mediapipe as mp
import json

mpDraw = mp.solutions.drawing_utils
mpPose = mp.solutions.pose
pose = mpPose.Pose()

# capture webcam image
cap = cv2.VideoCapture(0)

# get camera image parameters from get()
width = int(cap.get(cv2.CAP_PROP_FRAME_WIDTH))
height = int(cap.get(cv2.CAP_PROP_FRAME_HEIGHT))
codec = int(cap.get(cv2.CAP_PROP_CODEC_PIXEL_FORMAT))
print ('Video properties:')
print ('  Width = ' + str(width))
print ('  Height = ' + str(height))
print ('  Codec = ' + str(codec))

class Landmark:
    def __init__(self, id, x, y, z):
        self.id = id
        self.x = x
        self.y = y
        self.z = z


while True:
    # get video frame (always BGR format!)
    ret, frame = cap.read()
    if (ret):
        # copy image to draw on
        img = copy.copy(frame) 

        imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
        results = pose.process(imgRGB)
        if results.pose_landmarks:
            mpDraw.draw_landmarks(img, results.pose_landmarks,mpPose.POSE_CONNECTIONS)
            lmsList = []
            for id, lm in enumerate(results.pose_landmarks.landmark):
                h, w, c = img.shape
                # print(id, lm)
                landmark = {
                    "id": id,
                    "x": lm.x,
                    "y": lm.y,
                    "z": lm.z
                }
                #lmList = [id, lm.x, lm.y, lm.z]
                #newLandmark = Landmark(id,lm.x,lm.y,lm.z)
                lmsList.append(landmark)
                cx, cy = int(lm.x * w), int(lm.y * h)
            with open('landmarkData.json', 'w') as f:
                json.dump(lmsList, f, indent=2)

        # show the original image with drawings in one window
        cv2.imshow('Original image', img)

        # deal with keyboard input
        key = cv2.waitKey(10)
        if key == ord('q'): 
            break
    else:
        print('Could not start video camera')
        break

cap.release()
cv2.destroyAllWindows()

