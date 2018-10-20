import argparse
parser = argparse.ArgumentParser()
parser.add_argument("input", help="input apk")
parser.add_argument("output", help="output dir")
parser.add_argument('-e', action='store_true',
                    default=False,
                    help='Is encrypt?')
args = parser.parse_args()

print ("Decrypt DLL from %s to %s, is encode: %s" % (args.input, args.output, args.e))

def xor_string(data, key):
    from itertools import cycle
    return bytearray([x ^ y for (x, y) in zip(data, cycle(key))])

# key = bytearray.fromhex('95 CC 8E 8F 90 9C B7 87')
# test_data = bytearray.fromhex('4D 5A 90 00 03 00 00 00')
# print(xor_string(test_data, key))

src_file = open(args.input,'rb')
src = src_file.read()
src_file.close()

key = src[32:40]

dest_file = open(args.output,'rb+')
dest = dest_file.read()
dest_file.close()

dest_key = dest[32:40]
encrypted = bytes(dest_key).hex() != '0000000000000000'

with open(args.output,'rb+') as dest_file:
    if args.e != encrypted:
        dest = xor_string(dest, key)
        dest_file.write(dest)