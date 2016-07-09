// image is a PXCImage frame instance

PXCImage::ImageData data;
//Note:  image planes are in data.planes[0-3] with pitch data.pitches[0-3]
image->AcquireAccess(PXCImage::ACCESS_READ,&data);

Mat mat(int rows, int cols, int type)
//after that you can copy data in to your  mat from data above. Finally release access to data
image->ReleaseAccess(&data);


// Image is a stream

psm = PXCSenseManager::CreateInstance();

//then for each frame you do

PXCCapture::Sample *sample = psm->QuerySample();

PXCImage *rgbImage = sample->color; 

PXCImage::ImageData frmData;

rgbImage->AcquireAccess(PXCImage::ACCESS_READ, PXCIMAGE::PIXEL_FORMAT_NV12, &frmData);

//then you create a mat and copy the data over from frmData. Once you no longer need frmData, you just release the access

rgbImage->ReleaseAccess(&frmData);


//Input into CV
cv::Mat frameColor = cv::Mat::zeros(resolutionColor.height, resolutionColor.width, CV_8UC3);
cv::Mat frameDepth = cv::Mat::zeros(resolutionDepth.height, resolutionDepth.width, CV_32FC1);
cv::Mat frameIR = cv::Mat::zeros(resolutionIR.height, resolutionIR.width, CV_8UC1);