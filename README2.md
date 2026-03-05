# 💾 projnew: Project Template Cloning Tool

`projnew` is a cross-platform command-line tool designed to quickly scaffold new projects using existing Git repositories as templates. It supports powerful features like file content replacement and automated setup actions after cloning.

## Installation

**(Instructions for installation will go here once deployment method is finalized, e.g., using `dotnet tool install`.)**

## Usage

### 1. Create a New Project

The main command clones a specified template ID into a new directory named after the project name.

```bash
projnew <TemplateID> <ProjectName>
```

**Example:**
To create a new project named `my-new-app` using the template defined as `electron`:

```bash
projnew electron my-new-app
```

### 2\. List Available Templates

To see all templates defined in your configuration file:

```bash
projnew list
```

### 3\. Force Configuration Generation (`-g`)

To manually generate the default configuration file:

```bash
projnew --generate-config
# OR
projnew -g
```

This command attempts to generate the `projnew.templates.json` file in the **Global Configuration Path** (`$HOME/.projnew/`).

**Conflict Resolution:**
If the configuration file already exists in the global path, `projnew` will not overwrite it.

## Configuration File (`projnew.templates.json`)

### Location Priority (Portability First)

The tool searches for the configuration file in this order:

1.  **Global Path (Fallback):** `$HOME/.projnew/projnew.templates.json`.

If the file is not found, a sample file is **automatically generated** in the Global Path, and the session is marked as the "First Run."

### Template Schema Overview

Each template object includes:

| Field | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `id` | String | Yes | Unique ID used in the command line. |
| `sourceUrl` | String | Yes | The full URL of the Git repository to clone. |
| `fileReplacements` | Array | Optional | List of rules for replacing placeholder strings inside cloned files. |
| `postCloneActions` | Array | Optional | List of shell commands to execute after cloning (e.g., `npm install`). |

### Post-Clone Actions (`postCloneActions`) and Security

The commands in `postCloneActions` are executed by delegating to the OS shell (`cmd.exe` on Windows, `/bin/bash` on Linux/macOS).

**First Run Security Warning:**
If the configuration file was **automatically generated** by the tool, the user will be prompted with a security warning before any `postCloneActions` are executed to ensure self-responsibility: "Commands are run at your own risk. Proceed? (Y/N)".
