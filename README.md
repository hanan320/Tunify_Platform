# Tunify Platform

## Overview

**Tunify Platform** is a music management application designed to help users:

- Organize their music libraries
- Create and manage playlists
- Enjoy a rich experience with their favorite songs, albums, and artists

Key features include user management, subscription plans, and playlist management.

## Entity Relationship Diagram (ERD)

![Tunify ERD Diagram](Tunify.png)

## Entity Relationships

### Users

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Subscription**
    - Description: Each user has a subscription type.
    - Foreign Key (FK): `Subscription_ID` (references the `Subscriptions` table)
  - **Playlists**
    - Description: Users can create multiple playlists.
    - Foreign Key (FK): `User_ID` (in the `Playlists` table)

### Subscriptions

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**
    - Description: A subscription type can be associated with multiple users.
    - Foreign Key (FK): `Subscription_ID` (in the `Users` table)

### Artists

- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**
    - Description: Artists can have multiple songs.
    - Foreign Key (FK): `Artist_ID` (in the `Songs` table)
  - **Albums**
    - Description: Artists can release multiple albums.
    - Foreign Key (FK): `Artist_ID` (in the `Albums` table)

### Albums

- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**
    - Description: An album can contain multiple songs.
    - Foreign Key (FK): `Album_ID` (in the `Songs` table)
  - **Artist**
    - Description: Each album is released by an artist.
    - Foreign Key (FK): `Artist_ID` (in the `Albums` table)

### Songs

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Artists**
    - Description: Each song is performed by an artist.
    - Foreign Key (FK): `Artist_ID` (in the `Songs` table)
  - **Albums**
    - Description: Each song is part of an album.
    - Foreign Key (FK): `Album_ID` (in the `Songs` table)
  - **Playlists**
    - Description: Songs can be added to multiple playlists.
    - Link Table: `PlaylistSongs`

### Playlists

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**
    - Description: Each playlist is created by a user.
    - Foreign Key (FK): `User_ID` (in the `Playlists` table)
  - **Songs**
    - Description: Playlists can contain multiple songs.
    - Link Table: `PlaylistSongs`

### PlaylistSongs

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Playlists**
    - Description: Links songs to a playlist.
    - Foreign Key (FK): `Playlist_ID` (references the `Playlists` table)
  - **Songs**
    - Description: Links a song to a playlist.
    - Foreign Key (FK): `Song_ID` (references the `Songs` table)