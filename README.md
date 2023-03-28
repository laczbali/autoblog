# autoblog

A website, with a searchbar, where you can specify what kind of blogs you are interested in.
Upon searching, it generates a blog for you

- OpenAI to generate titles and contents
  - Use AI to check the search query of inappropriate content (ask it to rate it from 0-10, discard query if it's too bad)
  - Turn the search query into a list of keywords with AI (imagination set to low)
  - Use the keywords to ask it for headlines in a blog that has those keywords
  - Use the headlines + keyword to generate a blog name
  - Use headlines + keywords to generate blog posts
- Feed the headlines into Stable Diffusion to generate images 
- Keywords are stored, so the same search results in the already generated content
  - Content is stored in a folder named as the normalized blog name
  - There is a keywords-to-blogname lookup file
  - Return a link such as blog.com/blognameNormalized
    - Posts are: blog.com/blognameNormalized/headlineEncoded
  - In requests, after we asked for keywords, we check if we already have a blog for that
