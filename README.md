# ELLESEES
This is a video editor project I've wrote. Called it "ELLESEES" (Edit Less - Less Editing; See Everything - Everyone Sees). Yeah, if you call it stupid, I agree. I wasn't
familiar with video editing at the time and just assumed this one is powerful. However, it can edit videos in some ways, like contrast, advanced text tool, and other.

Since then, I just migrated to Clipchamp. Microsoft did a good job on that one. :D

# Learning tool
You can use ELLESEES as a learning tool to learn how to code up video editors with C#. If you ever get confused, please **do not hesitate** to open a discussion and write what you'd like to know when it comes to making video editors with C#, I'll be happy to help! For example:

### Title: How does ELLESEES add text to an image within given timestamps?
Body: *Can you please explain how does ELLESEES add text to an image within the given timestamp? Thanks in advance!*
### My response
ELLESEES adds text to an image with the following steps:
1. Extract frames within given timestamps to a folder like `temp`
2. Within all frames under the `temp` folder, we use `SixLabors.ImageSharp` to add text to all of those frames
3. We then add these frames back to the video, starting at a given timestamp and overwriting next frames.

# Screenshots
Start window:
![Screenshot1](https://github.com/winscripter/ELLESEES/assets/142818255/bd5dc608-5b98-45b0-a70a-0395827d11e3)

Editor UI (me adding text, timeline is a bit basic but I plan on improving it later):
![Screenshot2](https://github.com/winscripter/ELLESEES/assets/142818255/9d36c881-18e9-480e-a58d-64ab7092edff)
About window:
![Screenshot4](https://github.com/winscripter/ELLESEES/assets/142818255/5e8d0dc9-8453-405e-b39b-fe506500a91a)
Getting generously greeted by ELLESEES (occurs the first time you open an existing project):
![Screenshot3](https://github.com/winscripter/ELLESEES/assets/142818255/273483ab-a984-424f-a0bd-72bdf1c5d493)


# Too Basic
Announcement: I'm working on another video editor, this one is just too bad. No playback, half-linear, no way to stop exporting, no responsible UI, limited features, etc. The in-progress video editor should **theoretically** meet those requirements.
