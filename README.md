# ELLESEES
After 1.5 months of work and just about 400 lines of code less than 40,000 LoC, I'm very excited to announce ELLESEES! It stands for **Edit Less - Less Editing; See Everywhere - Everyone Sees**, e.g. **edit - infer**. This may not be a real motto right now, but as I keep updating the free video editor with more ideas coming into my mind I think the motto may eventually make sense. Either way, what else would I think of? 😂

ELLESEES runs on .NET 6.0, which means you need to download .NET 6.0 Runtime first to run ELLESEES. .NET 6.0 can run on a wide variety of systems, like Windows 7 and later, macOS, Linux, etc, but since ELLESEES is written using WPF it only runs on Windows.

Weights over 430MB, but who cares...

# Learning tool
You can use ELLESEES as a learning tool to learn how to code up video editors with C#. If you ever get confused, please **do not hesitate** to open an issue post and write what you'd like to know when it comes to making video editors with C#, I'll be happy to help! For example:

### Title: How does ELLESEES add text to an image within given timestamps?
Body: *Can you please explain how does ELLESEES add text to an image within the given timestamp? Thanks in advance!*
### My response
ELLESEES adds text to an image with the following steps:
1. Extract frames within given timestamps to a folder like `temp`
2. Within all frames under the `temp` folder, we use `SixLabors.ImageSharp` to add text to all of those frames
3. We then add these frames back to the video, starting at a given timestamp and overwriting next frames.

# The Great Thing about this Video Editor
While the video editor is powerful and nearly non-linear, it also consumes a **TON** of RAM during exports, especially when working with **ELLESEES VECI** (Video Extra Context &amp; Information). However, it doesn't consume much VRAM. The editor doesn't require any hardware requirements, so be cautious. Generally, I recommend using ELLESEES with at least 16GB RAM. The great thing about high memory usage but nearly no VRAM usage is that VRAM can't just be increased - you'll need to buy an expensive graphics card if you need more VRAM. Which is not the case for RAM, because RAM is extremely cheap compared to VRAM these days. For reference, 64GB RAM should run you about $400 in 2024.

# Updates
Feel free to post an issue if you want to suggest something new or report a bug on this video editor.

# Screenshots
Start window:
![Screenshot1](https://github.com/winscripter/ELLESEES/assets/142818255/bd5dc608-5b98-45b0-a70a-0395827d11e3)
Editor UI (me adding text, timeline is a bit basic but I plan on improving it later):
![Screenshot2](https://github.com/winscripter/ELLESEES/assets/142818255/9d36c881-18e9-480e-a58d-64ab7092edff)
About window:
![Screenshot4](https://github.com/winscripter/ELLESEES/assets/142818255/5e8d0dc9-8453-405e-b39b-fe506500a91a)
Getting generously greeted by ELLESEES (occurs the first time you open an existing project):
![Screenshot3](https://github.com/winscripter/ELLESEES/assets/142818255/273483ab-a984-424f-a0bd-72bdf1c5d493)

