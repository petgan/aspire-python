import logging

def main():
    # Reset the logging configuration to a sensible default.
    logging.basicConfig()
    logging.getLogger().setLevel(logging.NOTSET)

    # Write a basic log message.
    logging.getLogger(__name__).info("Hello from aspire-python-app1!")
    # print("Hello from aspire-python-app1!")

if __name__ == "__main__":
    main()
