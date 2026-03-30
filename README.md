# Prog6221-ST10443481

# 🛡️ Cybersecurity Awareness Chatbot for South African Citizens

[![.NET Version](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/)
[![C# Version](https://img.shields.io/badge/C%23-12.0-purple.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey.svg)]()

A comprehensive command-line cybersecurity awareness chatbot designed to educate South African citizens about online safety practices. This interactive application simulates real-life scenarios where users might encounter cyber threats and provides practical guidance on avoiding common traps.

## 📋 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage Guide](#usage-guide)
- [Topics Covered](#topics-covered)
- [Technical Architecture](#technical-architecture)
- [South African Context](#south-african-context)
- [Troubleshooting](#troubleshooting)
- [Future Enhancements](#future-enhancements)
- [Contributing](#contributing)
- [License](#license)

---

## 🎯 Overview

In recent years, South Africa has experienced a significant rise in cyberattacks targeting individuals, businesses, and government institutions. This chatbot serves as a "Cybersecurity Awareness Assistant" developed for the Department of Cybersecurity's public education campaign.

**Purpose:**
- Educate users about cybersecurity threats
- Provide practical advice on staying safe online
- Simulate real-life cybersecurity scenarios
- Empower South Africans with knowledge to protect themselves

**Target Audience:**
- South African citizens of all ages
- Individuals new to cybersecurity concepts
- Anyone wanting to improve their online safety

---

## ✨ Features

### Core Functionality
- 🎙️ **Voice Greeting**: Personalized welcome message using WAV audio
- 💬 **Interactive Conversations**: Natural language processing with keyword matching
- 🎨 **ASCII Art Display**: Visually appealing logo and interface
- 📚 **8 Cybersecurity Topics**: Comprehensive coverage of key areas
- 🔍 **Intelligent Response System**: Matches user questions to relevant topics
- 📊 **Session Tracking**: Logs conversation history and user statistics
- 🎯 **Input Validation**: Handles invalid inputs gracefully
- 🌍 **South African Context**: Local references and resources

### User Experience
- 🎨 Color-coded console output
- ⌨️ Typing effect for natural conversation
- 📋 Interactive menu system
- 💾 Conversation history logging
- 📈 Session summaries on exit
- 🔄 Graceful error handling

- Project Struceture

- CyberSecurityChatBot/
├── Program.cs # Application entry point
├── Chatbot.cs # Main chatbot logic & conversation flow
├── Models/ # Data models
│ ├── User.cs # User information storage
│ └── Conversation.cs # Conversation entry structure
├── Services/ # Core services
│ ├── AudioService.cs # Voice greeting playback
│ ├── KnowledgeBase.cs # Cybersecurity knowledge repository
│ └── UIService.cs # Console UI management
├── Resources/ # Static resources
│ └── Greetings.wav # Voice greeting audio file
├── TestChatbot.cs # Testing utility
├── TestAudio.cs # Audio testing utility
└── CyberSecurityChatBot.csproj # Project configuration


## 📁 Project Structure
