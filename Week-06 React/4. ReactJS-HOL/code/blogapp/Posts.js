// ✅ Step 1: Import React (No need to import Post class, we use plain JSON)
import React from 'react';

// ✅ Step 2: Create Class Component
class Posts extends React.Component {
  constructor(props) {
    super(props);
    // ✅ Step 3: Initialize state
    this.state = {
      posts: [],
      hasError: false
    };
  }

  // ✅ Step 4: Load posts from API (limited to 6)
  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then((response) => response.json())
      .then((data) => {
        const postList = data.slice(0, 6); // ✅ Limit to 6 posts
        this.setState({ posts: postList });
      })
      .catch((error) => {
        console.error('Fetch error:', error);
        this.setState({ hasError: true });
      });
  }

  // ✅ Step 5: Call loadPosts when component mounts
  componentDidMount() {
    this.loadPosts();
  }

  // ✅ Step 6: Catch rendering errors
  componentDidCatch(error, info) {
    alert('Something went wrong in Posts component.');
    console.error('Caught error:', error, info);
  }

  // ✅ Step 7: Render the posts
  render() {
    return (
      <div style={{ padding: '30px', backgroundColor: '#f2f5f9' }}>
        <h2 style={{ textAlign: 'center', color: '#333', marginBottom: '30px' }}>
          📚 Latest Blog Posts
        </h2>

        {/* ✅ Show posts */}
        {this.state.posts.map((post) => (
          <div
            key={post.id}
            style={{
              margin: '20px auto',
              maxWidth: '600px',
              border: '1px solid #ddd',
              padding: '20px',
              borderRadius: '8px',
              backgroundColor: '#ffffff',
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.05)',
              transition: 'transform 0.2s ease',
              cursor: 'pointer'
            }}
            onMouseEnter={(e) => (e.currentTarget.style.transform = 'scale(1.02)')}
            onMouseLeave={(e) => (e.currentTarget.style.transform = 'scale(1)')}
          >
            {/* ✅ Title */}
            <h3 style={{ color: '#2c3e50', marginBottom: '10px' }}>{post.title}</h3>

            {/* ✅ Body */}
            <p style={{ color: '#555' }}>
              {post.body || 'This is a blog post content. More details will be shown here.'}
            </p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
