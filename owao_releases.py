from telethon import TelegramClient
import requests

# GitHub repository information
GITHUB_REPO = "ruzen42/MalledeferOWASD"  # Replace with your GitHub repository in "username/repo" format
GITHUB_API_URL = f"# Replace with your channel username (e.g., "@yourchannel")

# Function to get the latest GitHub release information
def get_latest_release():
    try:
        response = requests.get(GITHUB_API_URL)
        response.raise_for_status()
        data = response.json()
        if data:
            release_name = data[0]["name"]
            release_url = data[0]["html_url"]
            return release_name, release_url
        else:
            print("Релизы отсутствуют.")
            return None, None
    except requests.RequestException as e:
        print(f"Ошибка получения данных релиза: {e}")
        return None, None
# Main script
async def main():
    # Connect to Telegram
    async with TelegramClient("session_name", API_ID, API_HASH) as client:
        release_name, release_url = get_latest_release()
        if release_name and release_url:
            message = f"Latest Release\n{release_name}\n[Посмотреть релиз]({release_url})"
            await client.send_message(CHANNEL_USERNAME, message, parse_mode="markdown")
            print("Сообщение успешно отправлено в Telegram канал.")
        else:
            print("Не удалось получить информацию о последнем релизе.")
# Run the main function
if __name__ == "__main__":
    import asyncio
    asyncio.run(main())
