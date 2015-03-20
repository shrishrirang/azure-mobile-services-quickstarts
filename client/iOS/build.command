# This bash script cleans and builds the Microsoft Azure Mobile Services QuickStart project

# First, we'll remove all previous artifacts created by this script
rm iOS_ObjC.zip
rm -rf WindowsAzureMobileServices.framework.zip
rm -rf ZUMOAPPNAME/WindowsAzureMobileServices.framework

# Second, copy the framework over into this directory
rsync -rlK $IOS_FRAMEWORK/WindowsAzureMobileServices.framework.zip
unzip WindowsAzureMobileServices.framework.zip -d ZUMOAPPNAME/WindowsAzureMobileServices.framework

# Ensure that there is not a build folder in the SDK
rm -rf ZUMOAPPNAME/Build 

# Zip the Quick Start and remove .DS_Store files
zip -r iOS_ObjC.zip ZUMOAPPNAME
zip -d iOS_ObjC.zip *.DS_Store

# Copy to the build share
if [ "$COPY_TO_SHARE" == "YES" ]; then
  SHARE_PATH_ARRAY=$(echo $QUICKSTART_SHARE_PATHS | tr ";" "\n")
  for SHARE_PATH in $SHARE_PATH_ARRAY
  do
    rsync -rlK iOS_ObjC.zip $SHARE_PATH
  done
fi

# Build the swift quickstart as well
bash ../iOS-Swift/build.command