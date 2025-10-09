# RP Names Plugin (Exiled)

![SCP:SL Plugin](https://img.shields.io/badge/SCP--SL%20Plugin-blue?style=for-the-badge)
![Language](https://img.shields.io/badge/Language-C%23-blueviolet?style=for-the-badge)
![Downloads](https://img.shields.io/github/downloads/ui2506/RpNames/total?label=Downloads&color=333333&style=for-the-badge)

A plugin for **SCP: Secret Laboratory** (based on **Exiled**) that assigns **RP names** to players depending on their team.

## Features

* Customizable name format for each **Team** (Chaos Insurgency, Class-D, Scientists, Foundation Forces, SCPs).
* Supports dynamic placeholders:

  * `%id%` — Player’s round ID
  * `%role%` — Player’s role
  * `%nick%` — Player’s nickname
  * `%rpname%` — Player’s RP name
  * `%random%` — Random 4-digit number
* **Fallback RP names** (`MainRpNames`) are used if the team’s RP names list is empty.
* Fully configurable via YAML.

## Example configuration

```yaml
MainRpNames:
  - OtherRPNames

NameConstructor:
  ChaosInsurgency:
    Format: "%id% | %rpname% | %nick%"
    RpNames: ["Coolguy", "Coolguy"]

  ClassD:
    Format: "%id% | D-%random% | %nick%"
    RpNames: ["CoolName"]

  FoundationForces:
    Format: "%id% | %rpname% | %nick%"
    RpNames: ["CoolName"]

  Scientists:
    Format: "%id% | %rpname% | %nick%"
    RpNames: ["CoolName"]

  SCPs:
    Format: "%id% | %role% | %nick%"
    RpNames: ["CoolName"]
```

## Use case

* Ideal for **RP servers**, where players need structured and role-based naming.
* Easy to extend and adjust for community needs.
