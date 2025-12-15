# projnew

## 🌟 `projnew`: The Cross-Platform Project Initializer

`projnew` is a simple, command-line tool designed to streamline new project creation from Git template repositories. It handles cloning, file content replacement (e.g., project name, year), Git history cleanup, and automated post-setup actions.

### Why `projnew`?

  * **Fast Setup:** Start development immediately without manual file edits.
  * **Template Driven:** Use any Git repository as a template.
  * **Automated Setup:** Run shell commands (e.g., `npm install`, `dotnet restore`) automatically after cloning.

## 🚀 Installation

### Prerequisites

  * **.NET 8.0 SDK** or later.
  * **Git** command line tool installed and accessible via your system's PATH.

### Installation Steps

```bash
# TODO: Add specific installation command (e.g., global tool install)
# Example: dotnet tool install -g projnew.cli
```

## 📋 Usage

`projnew` supports two main modes: creating a project and listing available templates.

### 1\. Creating a New Project (Main Command)

Use the template ID defined in `projnew.templates.json` and specify the desired new project name.

```bash
projnew <TEMPLATE_ID> <PROJECT_NAME>
```

| Argument | Description | Example |
| :--- | :--- | :--- |
| `<TEMPLATE_ID>` | The unique ID of the template (e.g., `electron`, `dotnet-api`). | `electron` |
| `<PROJECT_NAME>` | The name of the new directory to be created. | `my-new-app` |

### Options

| Option | Aliases | Description |
| :--- | :--- | :--- |
| `--keep-history` | `-k`, `--keep-git` | **Prevents** deletion of the template's Git history (`.git` directory) and skips the new `git init`. |

### 2\. Listing Available Templates (Subcommand)

Displays all templates defined in your local `projnew.templates.json` file.

```bash
projnew list
# Alias: projnew ls
```

**Example Output:**

```
Available Templates:
---------------------------------------------------------------------------------
ID            | Description
---------------------------------------------------------------------------------
electron      | Boilerplate for Electron + React + TypeScript
dotnet-api    | C# .NET 8 Web API (Minimal API) template
---------------------------------------------------------------------------------
```

## ⚙️ Template Definition (`projnew.templates.json`)

To enable template usage, you must define them in a `projnew.templates.json` file located in the `projnew` executable directory.

### JSON Structure

```json
{
  "templates": [
    {
      "id": "string",
      "description": "string",
      "sourceType": "git", // Currently only supports "git"
      "sourceUrl": "string", // SSH or HTTPS URL
      "fileReplacements": [ ... ],
      "postCloneActions": [ ... ]
    }
  ]
}
```

### File Content Replacement (`fileReplacements`)

This section automatically replaces specified placeholders in files within the cloned repository.

| Field | Type | Description |
| :--- | :--- | :--- |
| `fileName` | string | Path to the file to modify (relative to the new project root). |
| `placeholder` | string | The string to search for in the file. |
| `replacementValue`| string | The value to replace it with. |

**Available Internal Placeholders:**

| Placeholder | Replaced Value | Example |
| :--- | :--- | :--- |
| `{PROJECT_NAME}` | The name specified by the user (`<PROJECT_NAME>`). | `my-new-app` |
| `{CURRENT_YEAR}` | The current year (e.g., 2025). | `2025` |

### Post-Clone Actions (`postCloneActions`)

An array of shell commands to be executed in sequence after cloning and file replacement are complete. These are executed within the new project directory.

```json
"postCloneActions": [
    "npm install",
    "npm run setup",
    // Note: Use '&&' for multi-step commands if needed (e.g., 'cd sub-dir && npm install')
]
```

## ⚠️ Security Warning (Important)

### External Command Execution

When a template contains `postCloneActions`, `projnew` executes arbitrary commands (like `npm install` or `git checkout`) using your operating system's shell (`cmd` or `/bin/bash`).

**By using templates with post-clone actions, you acknowledge and agree to the following:**

> **PROJNEW DOES NOT VALIDATE THE CONTENT OF THESE COMMANDS. EXECUTION IS AT YOUR OWN RISK.**
>
> We strongly recommend only using templates from **trusted sources** that you have personally verified.
