# Implementation

## Features Implemented

- Create Event (stored in CSV)
- View Events (read from CSV)
- Find Event by ID
- Basic validation (title not empty, price > 0)

## Flow

UI → Service → Repository → CSV file

## Example Usage

User can:
1. Register/Login
2. Create an event
3. View all events
4. Find event by ID

## Notes

- Data is stored in events.csv
- Repository reads and writes from csv file
- Service validates input before saving
