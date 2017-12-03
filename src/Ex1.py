# coding = utf-8

def _Rot3(c, point, mode):
	if(mode == False):
		point *= -1

	# a-z,A-Zのみ対象
	if "A" <= c <= "Z":
		return chr((ord(c) - ord("A") + point) % 26 + ord("A"))

	if "a" <= c <= "z":
		return chr((ord(c) - ord("a") + point) % 26 + ord("a"))

	# その他の文字は対象外
	return c

def Rot3(s, point, mode):
	g = (_Rot3(c, point, mode) for c in s)
	return "".join(g)

def main():
	src = "The majestic red rock landscape here is awe inspiring, and I want to capture it with my camera. But the area is so vast that I can only see a part of it with my lens."
	shiftPoint = 3
	# 表示
	print(src)
	print("-" * 20)
	# 暗号化して表示
	dst = Rot3(src, shiftPoint, True)
	print(dst)
	print("-" * 20)
	# 復号化して表示
	result = Rot3(dst, shiftPoint, False)
	print(result)

if __name__ == '__main__':
	main()
