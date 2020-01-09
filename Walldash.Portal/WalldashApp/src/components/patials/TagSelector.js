import React, { Component } from "react";
import Fuse from "fuse.js";

class TagSelector extends Component {
  constructor(props) {
    super(props);

    this.state = {
      availableTags: [
        "department",
        "gender",
        "ressource",
        "lalandia",
        "heyo",
        "mom",
        "dad",
        "something",
        "aTag",
        "another",
        "one",
        "ressourceManagement",
        "bubber",
        "letsgo"
      ],
      search: ""
    };

    const options = {
      shouldSort: true,
      threshold: 0.6,
      location: 0,
      distance: 100,
      maxPatternLength: 32,
      minMatchCharLength: 1
    };

    this.fuse = new Fuse(this.state.availableTags, options);
  }

  addTag(tag) {
    this.setState({ availableTags: this.state.availableTags.filter(t => t !== tag) });
    this.props.onChange({ tags: [...this.props.tags, tag] });
    // this.setState({ selectedTags: [...this.state.selectedTags, tag] });
  }

  removeTag(tag) {
    this.setState({ availableTags: [...this.state.availableTags, tag] });
    this.props.onChange({ tags: [...this.props.tags.filter(t => t !== tag)] });
    // this.setState({ selectedTags: this.state.selectedTags.filter(t => t !== tag) });
  }

  renderSelectedTags() {
    const { tags } = this.props;
    if (!tags) {
      return "";
    }
    return (
      <div className='selected-tags'>
        {tags.map(tag => {
          return (
            <div key={tag} className='tag' onClick={() => this.removeTag(tag)}>
              {tag}
            </div>
          );
        })}
      </div>
    );
  }

  renderAvailableTags() {
    const { search } = this.state;
    const array = search ? this.fuse.search(search).map(i => this.fuse.list[i]) : this.fuse.list;
    return (
      <div className='available-tags'>
        {array.map(tag => {
          return (
            <div key={tag} className='tag' value={tag} onClick={() => this.addTag(tag)}>
              {tag}
            </div>
          );
        })}
      </div>
    );
  }

  render() {
    this.fuse.list = this.state.availableTags;
    const { search } = this.state;
    return (
      <div className='tag-selector'>
        <div className='title'>Tag Selector</div>
        <input value={search} placeholder='search for tags' onChange={e => this.setState({ search: e.target.value })} />
        {this.renderSelectedTags()}
        {this.renderAvailableTags()}
      </div>
    );
  }
}

export default TagSelector;
