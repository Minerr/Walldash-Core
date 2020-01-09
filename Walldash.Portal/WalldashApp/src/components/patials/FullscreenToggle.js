import React from "react";

const FullscreenToggle = () => {
  const elem = document.documentElement;

  const toggle = () => {
    const isFullScreen = document.fullScreen || document.webkitIsFullScreen || document.mozfullScreen;

    if (isFullScreen) {
      closeFullscreen();
    } else {
      openFullscreen();
    }
  };

  const openFullscreen = () => {
    if (elem.requestFullscreen) {
      elem.requestFullscreen();
    } else if (elem.mozRequestFullScreen) {
      /* Firefox */
      elem.mozRequestFullScreen();
    } else if (elem.webkitRequestFullscreen) {
      /* Chrome, Safari & Opera */
      elem.webkitRequestFullscreen();
    } else if (elem.msRequestFullscreen) {
      /* IE/Edge */
      elem.msRequestFullscreen();
    }
  };

  const closeFullscreen = () => {
    if (document.exitFullscreen) {
      document.exitFullscreen();
    } else if (document.mozCancelFullScreen) {
      document.mozCancelFullScreen();
    } else if (document.webkitExitFullscreen) {
      document.webkitExitFullscreen();
    } else if (document.msExitFullscreen) {
      document.msExitFullscreen();
    }
  };

  return (
    <div className='btn-full-screen-toggle' onClick={toggle}>
      Fullscreen
    </div>
  );
};

export default FullscreenToggle;
