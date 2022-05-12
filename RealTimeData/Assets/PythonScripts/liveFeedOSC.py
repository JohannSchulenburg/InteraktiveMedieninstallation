from re import X
import numpy as np
import cv2
import copy
import mediapipe as mp
import argparse
import random
import time
from pythonosc import udp_client

mpDraw = mp.solutions.drawing_utils
mpPose = mp.solutions.pose
pose = mpPose.Pose()

# capture webcam image
cap = cv2.VideoCapture(0)
#cap = cv2.VideoCapture('WorkItWillis.mp4')
# get camera image parameters from get()
width = int(cap.get(cv2.CAP_PROP_FRAME_WIDTH))
height = int(cap.get(cv2.CAP_PROP_FRAME_HEIGHT))
codec = int(cap.get(cv2.CAP_PROP_CODEC_PIXEL_FORMAT))
print ('Video properties:')
print ('  Width = ' + str(width))
print ('  Height = ' + str(height))
print ('  Codec = ' + str(codec))

parser = argparse.ArgumentParser()
parser.add_argument("--ip", default="127.0.0.1", help="The ip of the OSC server")
parser.add_argument("--port", type=int, default=7001, help="The port the OSC server is listening on")
args = parser.parse_args()

client = udp_client.SimpleUDPClient(args.ip, args.port)


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
            for id, lm in enumerate(results.pose_landmarks.landmark):
                h, w, c = img.shape
                if lm.visibility>0.7:
                    client.send_message(f"/message/landmark{id}", f"{id};{lm.x};{lm.y};{lm.z}")
                cx, cy = int(lm.x * w), int(lm.y * h)


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

